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
    containers: [],
    factories: [],
    utilities: [],
    activeTab: 0,
    addMarker: false,
    addMarkerCoord: null,
    addMarkerAddress: null,
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
                  onClick={() =>
                    this.setState({
                      activeTab: 0,
                      addMarker: false,
                      addMarkerCoord: null,
                    })
                  }
                >
                  Контейнер
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 1}
                  onClick={() =>
                    this.setState({
                      activeTab: 1,
                      addMarker: false,
                      addMarkerCoord: null,
                    })
                  }
                >
                  Регіон
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 2}
                  onClick={() =>
                    this.setState({
                      activeTab: 2,
                      addMarker: false,
                      addMarkerCoord: null,
                    })
                  }
                >
                  Будівля
                </NavLink>
              </NavItem>
            </Nav>
            <TabContent activeTab={activeTab.toString()}>
              <TabPane tabId="0">
                <ContainerForm
                  pickPoint={addMarker}
                  changePickPoint={() => this.changePickPoint()}
                  submitPoint={() => this.submitPoint()}
                  addAddress={addMarkerAddress}
                  changeAddress={(value) =>
                    this.setState({ addAddress: value })
                  }
                />
              </TabPane>
              <TabPane tabId="1">
                <RegionForm />
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
}

export default MapView;

const CustomMarker = ({ color, name }) => {
  return (
    <div style={{ width: "40px", height: "40px", backgroundColor: color }}>
      {name}
    </div>
  );
};
