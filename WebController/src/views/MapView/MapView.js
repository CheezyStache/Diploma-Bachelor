import React, { Component } from "react";
import GoogleMapReact from "google-map-react";
import { Row, Col } from "reactstrap";

const API_KEY = "AIzaSyA5DGX196CfHT3HcxrDF_qg1oBDqG9-KqE";

class MapView extends Component {
  static defaultProps = {
    center: {
      lat: 59.95,
      lng: 30.33,
    },
    zoom: 11,
  };

  render() {
    return (
      <div className="animated fadeIn">
        <Row>
          <Col xs="12">
            <div style={{ height: "75vh", width: "100%" }}>
              <GoogleMapReact
                bootstrapURLKeys={{
                  key: API_KEY,
                  language: "ua",
                  region: "ua",
                }}
                defaultCenter={this.props.center}
                defaultZoom={this.props.zoom}
              >
                <CustomMarker
                  lat={59.955413}
                  lng={30.337844}
                  text="My Marker"
                  color="#000000"
                />
              </GoogleMapReact>
            </div>
          </Col>
        </Row>
      </div>
    );
  }
}

export default MapView;

const CustomMarker = ({ color }) => {
  return (
    <div style={{ width: "40px", height: "40px", backgroundColor: color }}>
      Hello
    </div>
  );
};
