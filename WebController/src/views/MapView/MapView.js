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
import {
  ContainerMarker,
  FactoryMarker,
  UtilityMarker,
  AddMarker,
} from "./CustomMarkers";

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
    regions: [],
    polygons: [],
    activeTab: 0,
    google: null,
    addMarker: false,
    addMarkerCoord: null,
    addMarkerAddress: null,
    addMarkerRegion: null,
    regionPolygon: null,
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
                  <ContainerMarker
                    lat={d.location.latitude}
                    lng={d.location.longitude}
                    status={!d.full}
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
                {addMarkerCoord != null &&
                  (addMarker || addMarkerCoord.submit) && (
                    <AddMarker
                      lat={addMarkerCoord.lat}
                      lng={addMarkerCoord.lng}
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
                    this.setState({ addMarkerAddress: value })
                  }
                  submitAddress={() => this.submitAddress()}
                  saveContainer={(containerProps, callback) =>
                    this.saveContainer(containerProps, callback)
                  }
                />
              </TabPane>
              <TabPane tabId="1">
                <RegionForm
                  saveRegion={(regionProps, callback) =>
                    this.saveRegion(regionProps, callback)
                  }
                  resetRegion={() => {
                    this.state.regionPolygon &&
                      this.state.regionPolygon.setMap(null);
                    this.createRegion();
                  }}
                />
              </TabPane>
              <TabPane tabId="2">
                <BuildingForm
                  pickPoint={addMarker}
                  changePickPoint={() => this.changePickPoint()}
                  submitPoint={() => this.submitPoint()}
                  addAddress={addMarkerAddress}
                  changeAddress={(value) =>
                    this.setState({ addMarkerAddress: value })
                  }
                  changeAddress={() => this.submitAddress()}
                  saveBuilding={(buildingProps, callback) =>
                    this.saveBuilding(buildingProps, callback)
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
    this.setState(
      {
        google: google,
      },
      () =>
        this.state.polygons.length === 0 && this.drawRegions(this.state.regions)
    );
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

  drawRegions = (maps) => {
    let regions = [];

    maps.forEach((m, index) => {
      const region = this.drawRegion(m.map, index);
      regions.push(region);
    });

    this.setState({ polygons: regions });
  };

  drawRegion = (map, index) => {
    const randomColor = Math.floor(Math.random() * 16777215).toString(16);

    const polygon = new this.state.google.maps.Polygon({
      map: this.state.google.map,
      paths: JSON.parse(map),
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
      if (this.state.addMarker) this.setState({ addMarkerRegion: index + 1 });
    });

    return polygon;
  };

  navLinkClear = (index) => {
    this.setState({
      activeTab: index,
      addMarker: false,
      addMarkerCoord: null,
      addMarkerRegion: null,
      addMarkerAddress: null,
      regionPolygon: null,
    });
  };

  submitAddress = () => {
    if (this.state.addMarkerAddress) {
      this.getPoint(this.state.addMarkerAddress).then((point) => {
        let regionIndex = -1;

        for (let i = 0; i < this.state.regions.length; i++) {
          if (
            this.state.google.maps.geometry.poly.containsLocation(
              new this.state.google.maps.LatLng(point.lat, point.lng),
              this.state.polygons[i]
            )
          ) {
            regionIndex = i + 1;
            break;
          }
        }

        if (regionIndex === -1) {
          console.log("No region");
          this.setState({
            addMarkerAddress: null,
          });
          return;
        }

        this.setState({
          addMarkerCoord: { lat: point.lat, lng: point.lng, submit: true },
          addMarkerAddress: point.address,
          addMarkerRegion: regionIndex,
        });
      });
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

  async saveRegion(regionProps, callback) {
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

    const response = await result.text();
    if (response === "1") {
      this.setState({
        polygons: [
          ...this.state.polygons,
          this.drawRegion(JSON.stringify(path), this.state.polygons.length),
        ],
      });

      this.state.regionPolygon && this.state.regionPolygon.setMap(null);
      this.navLinkClear(this.state.activeTab);

      callback();
    }
  }

  async saveContainer(containerProps, callback) {
    const container = {
      ...containerProps,
      location: {
        lat: this.state.addMarkerCoord.lat,
        lng: this.state.addMarkerCoord.lng,
      },
      address: this.state.addMarkerAddress,
      region: this.state.addMarkerRegion,
    };

    const result = await fetch("http://localhost:50398/api/save/container", {
      method: "POST",
      body: JSON.stringify(container),
      headers: {
        "Content-Type": "application/json",
      },
    });

    const response = await result.text();
    if (response === "1") {
      this.setState({
        containers: [
          ...this.state.containers,
          {
            location: {
              latitude: container.location.lat,
              longitude: container.location.lng,
            },
            full: false,
            id: this.state.containers.length,
          },
        ],
      });

      this.state.regionPolygon && this.state.regionPolygon.setMap(null);
      this.navLinkClear(this.state.activeTab);

      callback();
    }
  }

  async saveBuilding(buildingProps, callback) {
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

    const response = await result.text();
    if (response === "1") {
      if (building.type === 0)
        this.setState({
          utilities: [
            ...this.state.utilities,
            {
              location: {
                latitude: building.location.lat,
                longitude: building.location.lng,
              },
              ready: building.ready,
              id: this.state.utilities.length,
            },
          ],
        });
      else
        this.setState({
          factories: [
            ...this.state.factories,
            {
              location: {
                latitude: building.location.lat,
                longitude: building.location.lng,
              },
              ready: building.ready,
              id: this.state.factories.length,
            },
          ],
        });

      this.state.regionPolygon && this.state.regionPolygon.setMap(null);
      this.navLinkClear(this.state.activeTab);

      callback();
    }
  }
}

export default MapView;
