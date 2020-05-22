import React, { Component } from "react";
import GoogleMapReact from "google-map-react";
import {
  Row,
  Col,
  TabContent,
  TabPane,
  Nav,
  NavItem,
  NavLink,
} from "reactstrap";
import ContainerForm from "./ContainerForm";
import BuildingForm from "./BuildingForm";
import RegionForm from "./RegionForm";

const API_KEY = "AIzaSyA5DGX196CfHT3HcxrDF_qg1oBDqG9-KqE";

class MapView extends Component {
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
    activeTab: 0,
    addMarker: false,
    addMarkerCoord: null,
    addMarkerAddress: null,
    google: null,
    regionPolygon: null,
  };

  componentDidMount() {
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
    const {
      containers,
      factories,
      utilities,
      activeTab,
      addMarker,
      addMarkerCoord,
      addMarkerAddress,
      google,
      regionPolygon,
    } = this.state;

    return (
      <div className="animated fadeIn">
        <Row>
          <Col xs="8">
            <div style={{ height: "75vh", width: "100%" }}>
              <GoogleMapReact
                bootstrapURLKeys={{
                  key: API_KEY,
                  language: "ua",
                  region: "ua",
                }}
                defaultCenter={this.props.center}
                defaultZoom={this.props.zoom}
                onClick={(mapObj) => addMarker && this.onClick(mapObj)}
                onGoogleApiLoaded={(google) => this.handleGoogleMapApi(google)}
              >
                {containers.map((d) => (
                  <CustomMarker
                    lat={d.location.latitude}
                    lng={d.location.longitude}
                    color={d.full ? "red" : "green"}
                    name="Container"
                    key={"Marker" + d.id}
                  />
                ))}
                {factories.map((f) => (
                  <CustomMarker
                    lat={f.location.latitude}
                    lng={f.location.longitude}
                    color={f.ready ? "green" : "red"}
                    name="Factory"
                    key={"Marker" + f.id}
                  />
                ))}
                {utilities.map((u) => (
                  <CustomMarker
                    lat={u.location.latitude}
                    lng={u.location.longitude}
                    color={u.ready ? "green" : "red"}
                    name="Utility"
                    key={"Marker" + u.id}
                  />
                ))}
                {addMarkerCoord != null &&
                  (addMarker || addMarkerCoord.submit) && (
                    <CustomMarker
                      lat={addMarkerCoord.lat}
                      lng={addMarkerCoord.lng}
                      color={"blue"}
                      name="AddMarker"
                    />
                  )}
              </GoogleMapReact>
            </div>
          </Col>
          <Col xs="4">
            <Nav tabs>
              <NavItem>
                <NavLink
                  active={activeTab === 0}
                  onClick={() => {
                    this.state.regionPolygon &&
                      this.state.regionPolygon.setMap(null);
                    this.navLinkClear(0);
                  }}
                >
                  Контейнер
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 1}
                  onClick={() => {
                    this.navLinkClear(1);
                    this.createRegion();
                  }}
                >
                  Регіон
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 2}
                  onClick={() => {
                    this.state.regionPolygon &&
                      this.state.regionPolygon.setMap(null);
                    this.navLinkClear(2);
                  }}
                >
                  Будівля
                </NavLink>
              </NavItem>
            </Nav>
            <TabContent
              activeTab={activeTab.toString()}
              style={{ marginBottom: "10px" }}
            >
              <TabPane tabId="0">
                <ContainerForm
                  pickPoint={addMarker}
                  changePickPoint={() => this.changePickPoint()}
                  submitPoint={() => this.submitPoint()}
                  addAddress={addMarkerAddress}
                  changeAddress={(value) =>
                    this.setState({ addAddress: value })
                  }
                  submitAddress={() => this.submitAddress()}
                  saveContainer={(containerProps) =>
                    this.saveContainer(containerProps)
                  }
                />
              </TabPane>
              <TabPane tabId="1">
                <RegionForm
                  saveRegion={(regionProps) => this.saveRegion(regionProps)}
                />
              </TabPane>
              <TabPane tabId="2">
                <BuildingForm
                  pickPoint={addMarker}
                  changePickPoint={() => this.changePickPoint()}
                  submitPoint={() => this.submitPoint()}
                  addAddress={addMarkerAddress}
                  changeAddress={(value) =>
                    this.setState({ addAddress: value })
                  }
                  changeAddress={() => this.submitAddress()}
                  saveBuilding={(buildingProps) =>
                    this.saveBuilding(buildingProps)
                  }
                />
              </TabPane>
            </TabContent>
          </Col>
        </Row>
      </div>
    );
  }

  onClick(mapObj) {
    const lat = mapObj.lat;
    const lng = mapObj.lng;

    this.setState({ addMarkerCoord: { lat: lat, lng: lng, submit: false } });
  }

  changePickPoint() {
    if (this.state.addMarkerCoord && !this.state.addMarkerCoord.submit)
      this.setState({ addMarkerCoord: null, addMarkerAddress: null });
    this.setState({ addMarker: !this.state.addMarker });
  }

  submitPoint() {
    if (this.state.addMarkerCoord) {
      this.getAddress(
        this.state.addMarkerCoord.lat,
        this.state.addMarkerCoord.lng
      ).then((address) =>
        this.setState({
          addMarkerCoord: { ...this.state.addMarkerCoord, submit: true },
          addMarkerAddress: address,
        })
      );
    }
  }

  async getAddress(lat, lng) {
    const address = await fetch(
      `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${lng}&key=${API_KEY}`
    )
      .then((response) => response.json())
      .then((result) => result.results[0].formatted_address);

    return address;
  }

  handleGoogleMapApi = (google) => {
    // Construct a draggable red triangle with geodesic set to true.
    this.setState({
      google: google,
    });
  };

  createRegion = () => {
    let centerCoords = this.state.google.map.getCenter();
    centerCoords = { lat: centerCoords.lat(), lng: centerCoords.lng() };

    const regionCoords = [
      { lat: centerCoords.lat, lng: centerCoords.lng },
      { lat: centerCoords.lat + 0.01, lng: centerCoords.lng },
      { lat: centerCoords.lat, lng: centerCoords.lng + 0.01 },
    ];

    const region = new this.state.google.maps.Polygon({
      map: this.state.google.map,
      paths: regionCoords,
      strokeColor: "#0000FF",
      strokeOpacity: 0.8,
      strokeWeight: 2,
      fillColor: "#0000FF",
      fillOpacity: 0.35,
      draggable: true,
      editable: true,
      geodesic: false,
    });

    this.setState({ regionPolygon: region });
  };

  navLinkClear = (index) => {
    this.setState({
      activeTab: index,
      addMarker: false,
      addMarkerCoord: null,
      regionPolygon: null,
    });
  };

  submitAddress = () => {
    if (this.state.addAddress) {
      this.getPoint(this.state.addAddress).then((point) =>
        this.setState({
          addMarkerCoord: { lat: point.lat, lng: point.lng, submit: true },
          addMarkerAddress: point.address,
        })
      );
    }
  };

  async getPoint(address) {
    const point = await fetch(
      `https://maps.googleapis.com/maps/api/geocode/json?address=${address.replace(
        " ",
        "+"
      )}&key=${API_KEY}`
    )
      .then((response) => response.json())
      .then((result) => result.results[0]);

    return {
      address: point.formatted_address,
      lat: point.geometry.location.lat,
      lng: point.geometry.location.lng,
    };
  }

  async saveRegion(regionProps) {
    const path = this.state.regionPolygon
      .getPath()
      .getArray()
      .map((r) => r.toJSON());
    const region = { ...regionProps, city: this.state.city, path: path };

    const result = await fetch("http://localhost:50398/api/save/region", {
      method: "POST",
      body: JSON.stringify(region),
      headers: {
        "Content-Type": "application/json",
      },
    });

    console.log(await result.text());
  }

  async saveContainer(containerProps) {
    const container = {
      ...containerProps,
      location: {
        lat: this.state.addMarkerCoord.lat,
        lng: this.state.addMarkerCoord.lng,
      },
      address: this.state.addMarkerAddress,
      region: 1,
    };

    const result = await fetch("http://localhost:50398/api/save/container", {
      method: "POST",
      body: JSON.stringify(container),
      headers: {
        "Content-Type": "application/json",
      },
    });

    console.log(await result.text());
  }

  async saveBuilding(buildingProps) {
    const building = {
      ...buildingProps,
      location: {
        lat: this.state.addMarkerCoord.lat,
        lng: this.state.addMarkerCoord.lng,
      },
      address: this.state.addMarkerAddress,
    };

    const result = await fetch("http://localhost:50398/api/save/building", {
      method: "POST",
      body: JSON.stringify(building),
      headers: {
        "Content-Type": "application/json",
      },
    });

    console.log(await result.text());
  }
}

export default MapView;

const CustomMarker = ({ color, name }) => {
  return (
    <div style={{ width: "40px", height: "40px", backgroundColor: color }}>
      {name}
    </div>
  );
};
