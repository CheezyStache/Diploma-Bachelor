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
    const { containers, factories, utilities, activeTab } = this.state;

    return (
      <div className="animated fadeIn">
        <Row>
          <Col xs="8">
            <div style={{ height: "75vh", width: "100%" }}>
              {/* <GoogleMapReact
                bootstrapURLKeys={{
                  key: API_KEY,
                  language: "ua",
                  region: "ua",
                }}
                defaultCenter={this.props.center}
                defaultZoom={this.props.zoom}
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
              </GoogleMapReact> */}
            </div>
          </Col>
          <Col xs="4">
            <Nav tabs>
              <NavItem>
                <NavLink
                  active={activeTab === 0}
                  onClick={() => this.setState({ activeTab: 0 })}
                >
                  Контейнер
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 1}
                  onClick={() => this.setState({ activeTab: 1 })}
                >
                  Регіон
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  active={activeTab === 2}
                  onClick={() => this.setState({ activeTab: 2 })}
                >
                  Будівля
                </NavLink>
              </NavItem>
            </Nav>
            <TabContent activeTab={activeTab.toString()}>
              <TabPane tabId="0">
                <ContainerForm />
              </TabPane>
              <TabPane tabId="1">
                <RegionForm />
              </TabPane>
              <TabPane tabId="2">
                <BuildingForm />
              </TabPane>
            </TabContent>
          </Col>
        </Row>
      </div>
    );
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
