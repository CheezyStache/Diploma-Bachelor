import React, { Component } from "react";
import {
  Row,
  Col,
  Card,
  CardHeader,
  CardBody,
  Form,
  FormGroup,
  Label,
  CardFooter,
  Button,
} from "reactstrap";
import {
  ContainerMarker,
  FactoryMarker,
  UtilityMarker,
} from "../MapView/CustomMarkers";
import GoogleMapReact from "google-map-react";

const API_KEY = "AIzaSyA5DGX196CfHT3HcxrDF_qg1oBDqG9-KqE";

class Test extends Component {
  static defaultProps = {
    center: {
      lat: 50.469418,
      lng: 30.485759,
    },
    zoom: 11,
  };

  state = {
    city: 1,
    containers: [],
    factories: [],
    utilities: [],
    regions: [],
    polygons: [],
    google: null,
    calculateRegion: 0,
    regionName: "",
    path: null,
    polyline: null,
  };

  componentDidMount() {
    fetch("http://localhost:50398/api/map/regions").then((response) => {
      return response.json().then((result) => {
        this.setState({ regions: result });
        this.state.google != null && this.drawRegions(result);
      });
    });

    fetch("http://localhost:50398/api/map/containers").then((response) => {
      return response
        .json()
        .then((result) => this.setState({ containers: result }));
    });

    fetch("http://localhost:50398/api/map/factories").then((response) => {
      return response
        .json()
        .then((result) => this.setState({ factories: result }));
    });

    fetch("http://localhost:50398/api/map/utilities").then((response) => {
      return response
        .json()
        .then((result) => this.setState({ utilities: result }));
    });
  }

  render() {
    const { containers, factories, utilities, regionName } = this.state;

    return (
      <div className="animated fadeIn">
        <Row>
          <Col xs="10">
            <div style={{ height: "75vh", width: "100%" }}>
              <GoogleMapReact
                bootstrapURLKeys={{
                  key: API_KEY,
                  language: "ua",
                  region: "ua",
                }}
                defaultCenter={this.props.center}
                defaultZoom={this.props.zoom}
                onGoogleApiLoaded={(google) => this.handleGoogleMapApi(google)}
              >
                {containers.map((d) => (
                  <ContainerMarker
                    lat={d.location.latitude}
                    lng={d.location.longitude}
                    status={!d.full}
                    notReady={!d.ready}
                    key={"Marker_Container" + d.id}
                  />
                ))}
                {factories.map((f) => (
                  <FactoryMarker
                    lat={f.location.latitude}
                    lng={f.location.longitude}
                    status={f.ready}
                    key={"Marker_Factory" + f.id}
                  />
                ))}
                {utilities.map((u) => (
                  <UtilityMarker
                    lat={u.location.latitude}
                    lng={u.location.longitude}
                    status={u.ready}
                    key={"Marker_Utility" + u.id}
                  />
                ))}
              </GoogleMapReact>
            </div>
          </Col>
          <Col xs="2">
            <Row>
              <Card>
                <CardHeader>
                  <strong>Створення маршруту</strong>
                  <br />
                  за регіоном
                </CardHeader>
                <CardBody>
                  <strong>Регіон</strong>
                  <p className="form-control-static">
                    {regionName === "" ? "Не обрано" : regionName}
                  </p>
                  <p className="form-control-static">
                    Клікніть на потрібний район
                  </p>
                </CardBody>
                <CardFooter>
                  <Button
                    size="sm"
                    color="primary"
                    onClick={() => this.getTrip()}
                  >
                    <i className="fa fa-dot-circle-o"></i> Пітдвердити
                  </Button>
                </CardFooter>
              </Card>
              <Card>
                <CardHeader>
                  <strong>Підключення контейнерів</strong>
                  <br />
                  за регіоном
                </CardHeader>
                <CardBody>
                  <strong>Регіон</strong>
                  <p className="form-control-static">
                    {regionName === "" ? "Не обрано" : regionName}
                  </p>
                  <p className="form-control-static">
                    Клікніть на потрібний район
                  </p>
                </CardBody>
                <CardFooter>
                  <Button
                    size="sm"
                    color="primary"
                    onClick={() => this.connectContainers()}
                  >
                    <i className="fa fa-dot-circle-o"></i> Пітдвердити
                  </Button>
                </CardFooter>
              </Card>
            </Row>
          </Col>
        </Row>
      </div>
    );
  }

  handleGoogleMapApi = (google) => {
    // Construct a draggable red triangle with geodesic set to true.
    this.setState(
      {
        google: google,
      },
      () =>
        this.state.polygons.length === 0 && this.drawRegions(this.state.regions)
    );
  };

  drawRegions = (maps) => {
    let regions = [];

    maps.forEach((m) => {
      const region = this.drawRegion(m);
      regions.push(region);
    });

    this.setState({ polygons: regions });
  };

  drawRegion = (map) => {
    const randomColor = Math.floor(Math.random() * 16777215).toString(16);

    const polygon = new this.state.google.maps.Polygon({
      map: this.state.google.map,
      paths: JSON.parse(map.map),
      strokeColor: "#" + randomColor,
      strokeOpacity: 0.8,
      strokeWeight: 2,
      fillColor: "#" + randomColor,
      fillOpacity: 0.35,
      draggable: false,
      editable: false,
      geodesic: false,
    });

    polygon.addListener("click", () => {
      this.setState({ calculateRegion: map.id, regionName: map.name });
    });

    return polygon;
  };

  getTrip() {
    fetch(
      "http://localhost:50398/api/trip/trip/" + this.state.calculateRegion
    ).then((response) => {
      response.json().then((result) => {
        this.setState({ path: result });
        this.drawTrip(result);
      });
    });
  }

  drawTrip(trip) {
    if (polyline) polyline.setMap(null);

    const path = trip.map((t) => ({ lat: t.latitude, lng: t.longitude }));
    console.log(path);
    const polyline = new this.state.google.maps.Polyline({
      map: this.state.google.map,
      path: path,
      strokeColor: "#ff0000",
      strokeOpacity: 1.0,
      strokeWeight: 2,
    });

    this.setState({ polyline: polyline });
  }

  async connectContainers() {
    const response = await fetch(
      "http://localhost:50398/api/settings/region/" + this.state.calculateRegion
    );

    const status = await response.text();

    if (status === "1") {
      fetch("http://localhost:50398/api/map/containers").then((response) => {
        response.json().then((result) => this.setState({ containers: result }));
      });
    }
  }
}

export default Test;
