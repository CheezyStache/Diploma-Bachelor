import React, { Component, lazy, Suspense } from "react";
import { Bar, Line } from "react-chartjs-2";
import {
  Badge,
  Button,
  ButtonDropdown,
  ButtonGroup,
  ButtonToolbar,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  CardTitle,
  Col,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Progress,
  Row,
  Table,
} from "reactstrap";
import { CustomTooltips } from "@coreui/coreui-plugin-chartjs-custom-tooltips";
import { getStyle, hexToRgba } from "@coreui/coreui/dist/js/coreui-utilities";
import Widget02 from "../../Widgets/Widget02";

const Widget03 = lazy(() => import("../../Widgets/Widget03"));

const brandPrimary = getStyle("--primary");
const brandSuccess = getStyle("--success");
const brandInfo = getStyle("--info");
const brandWarning = getStyle("--warning");
const brandDanger = getStyle("--danger");

// Card Chart 1
const cardChartData1 = {
  labels: ["January", "February", "March", "April", "May", "June", "July"],
  datasets: [
    {
      label: "My First dataset",
      backgroundColor: brandPrimary,
      borderColor: "rgba(255,255,255,.55)",
      data: [65, 59, 84, 84, 51, 55, 40],
    },
  ],
};

const cardChartOpts1 = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        gridLines: {
          color: "transparent",
          zeroLineColor: "transparent",
        },
        ticks: {
          fontSize: 2,
          fontColor: "transparent",
        },
      },
    ],
    yAxes: [
      {
        display: false,
        ticks: {
          display: false,
          min: Math.min.apply(Math, cardChartData1.datasets[0].data) - 5,
          max: Math.max.apply(Math, cardChartData1.datasets[0].data) + 5,
        },
      },
    ],
  },
  elements: {
    line: {
      borderWidth: 1,
    },
    point: {
      radius: 4,
      hitRadius: 10,
      hoverRadius: 4,
    },
  },
};

// Card Chart 2
const cardChartData2 = {
  labels: ["January", "February", "March", "April", "May", "June", "July"],
  datasets: [
    {
      label: "My First dataset",
      backgroundColor: brandInfo,
      borderColor: "rgba(255,255,255,.55)",
      data: [1, 18, 9, 17, 34, 22, 11],
    },
  ],
};

const cardChartOpts2 = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        gridLines: {
          color: "transparent",
          zeroLineColor: "transparent",
        },
        ticks: {
          fontSize: 2,
          fontColor: "transparent",
        },
      },
    ],
    yAxes: [
      {
        display: false,
        ticks: {
          display: false,
          min: Math.min.apply(Math, cardChartData2.datasets[0].data) - 5,
          max: Math.max.apply(Math, cardChartData2.datasets[0].data) + 5,
        },
      },
    ],
  },
  elements: {
    line: {
      tension: 0.00001,
      borderWidth: 1,
    },
    point: {
      radius: 4,
      hitRadius: 10,
      hoverRadius: 4,
    },
  },
};

// Card Chart 3
const cardChartData3 = {
  labels: ["January", "February", "March", "April", "May", "June", "July"],
  datasets: [
    {
      label: "My First dataset",
      backgroundColor: "rgba(255,255,255,.2)",
      borderColor: "rgba(255,255,255,.55)",
      data: [78, 81, 80, 45, 34, 12, 40],
    },
  ],
};

const cardChartOpts3 = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        display: false,
      },
    ],
    yAxes: [
      {
        display: false,
      },
    ],
  },
  elements: {
    line: {
      borderWidth: 2,
    },
    point: {
      radius: 0,
      hitRadius: 10,
      hoverRadius: 4,
    },
  },
};

// Card Chart 4
const cardChartData4 = {
  labels: ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""],
  datasets: [
    {
      label: "My First dataset",
      backgroundColor: "rgba(255,255,255,.3)",
      borderColor: "transparent",
      data: [78, 81, 80, 45, 34, 12, 40, 75, 34, 89, 32, 68, 54, 72, 18, 98],
    },
  ],
};

const cardChartOpts4 = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        display: false,
        barPercentage: 0.6,
      },
    ],
    yAxes: [
      {
        display: false,
      },
    ],
  },
};

// Social Box Chart
const socialBoxData = [
  { data: [65, 59, 84, 84, 51, 55, 40], label: "facebook" },
  { data: [1, 13, 9, 17, 34, 41, 38], label: "twitter" },
  { data: [78, 81, 80, 45, 34, 12, 40], label: "linkedin" },
  { data: [35, 23, 56, 22, 97, 23, 64], label: "google" },
];

const makeSocialBoxData = (dataSetNo) => {
  const dataset = socialBoxData[dataSetNo];
  const data = {
    labels: ["January", "February", "March", "April", "May", "June", "July"],
    datasets: [
      {
        backgroundColor: "rgba(255,255,255,.1)",
        borderColor: "rgba(255,255,255,.55)",
        pointHoverBackgroundColor: "#fff",
        borderWidth: 2,
        data: dataset.data,
        label: dataset.label,
      },
    ],
  };
  return () => data;
};

const socialChartOpts = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  responsive: true,
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        display: false,
      },
    ],
    yAxes: [
      {
        display: false,
      },
    ],
  },
  elements: {
    point: {
      radius: 0,
      hitRadius: 10,
      hoverRadius: 4,
      hoverBorderWidth: 3,
    },
  },
};

// sparkline charts
const sparkLineChartData = [
  {
    data: [35, 23, 56, 22, 97, 23, 64],
    label: "New Clients",
  },
  {
    data: [65, 59, 84, 84, 51, 55, 40],
    label: "Recurring Clients",
  },
  {
    data: [35, 23, 56, 22, 97, 23, 64],
    label: "Pageviews",
  },
  {
    data: [65, 59, 84, 84, 51, 55, 40],
    label: "Organic",
  },
  {
    data: [78, 81, 80, 45, 34, 12, 40],
    label: "CTR",
  },
  {
    data: [1, 13, 9, 17, 34, 41, 38],
    label: "Bounce Rate",
  },
];

const makeSparkLineData = (dataSetNo, variant) => {
  const dataset = sparkLineChartData[dataSetNo];
  const data = {
    labels: [
      "Monday",
      "Tuesday",
      "Wednesday",
      "Thursday",
      "Friday",
      "Saturday",
      "Sunday",
    ],
    datasets: [
      {
        backgroundColor: "transparent",
        borderColor: variant ? variant : "#c2cfd6",
        data: dataset.data,
        label: dataset.label,
      },
    ],
  };
  return () => data;
};

const sparklineChartOpts = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
  },
  responsive: true,
  maintainAspectRatio: true,
  scales: {
    xAxes: [
      {
        display: false,
      },
    ],
    yAxes: [
      {
        display: false,
      },
    ],
  },
  elements: {
    line: {
      borderWidth: 2,
    },
    point: {
      radius: 0,
      hitRadius: 10,
      hoverRadius: 4,
      hoverBorderWidth: 3,
    },
  },
  legend: {
    display: false,
  },
};

// Main Chart

//Random Numbers
function random(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

var elements = 27;
var data1 = [];
var data2 = [];
var data3 = [];

for (var i = 0; i <= elements; i++) {
  data1.push(random(50, 200));
  data2.push(random(80, 100));
  data3.push(65);
}

const mainChart = {
  labels: [
    "Mo",
    "Tu",
    "We",
    "Th",
    "Fr",
    "Sa",
    "Su",
    "Mo",
    "Tu",
    "We",
    "Th",
    "Fr",
    "Sa",
    "Su",
    "Mo",
    "Tu",
    "We",
    "Th",
    "Fr",
    "Sa",
    "Su",
    "Mo",
    "Tu",
    "We",
    "Th",
    "Fr",
    "Sa",
    "Su",
  ],
  datasets: [
    {
      label: "Ukraine",
      backgroundColor: hexToRgba(brandInfo, 10),
      borderColor: brandInfo,
      pointHoverBackgroundColor: "#fff",
      borderWidth: 2,
      data: data1,
    },
    {
      label: "Kyiv",
      backgroundColor: "transparent",
      borderColor: brandSuccess,
      pointHoverBackgroundColor: "#fff",
      borderWidth: 2,
      data: data2,
    },
    {
      label: "Kyiv Today",
      backgroundColor: "transparent",
      borderColor: brandDanger,
      pointHoverBackgroundColor: "#fff",
      borderWidth: 1,
      borderDash: [8, 5],
      data: data3,
    },
  ],
};

const mainChartOpts = {
  tooltips: {
    enabled: false,
    custom: CustomTooltips,
    intersect: true,
    mode: "index",
    position: "nearest",
    callbacks: {
      labelColor: function (tooltipItem, chart) {
        return {
          backgroundColor:
            chart.data.datasets[tooltipItem.datasetIndex].borderColor,
        };
      },
    },
  },
  maintainAspectRatio: false,
  legend: {
    display: false,
  },
  scales: {
    xAxes: [
      {
        gridLines: {
          drawOnChartArea: false,
        },
      },
    ],
    yAxes: [
      {
        ticks: {
          beginAtZero: true,
          maxTicksLimit: 5,
          stepSize: Math.ceil(250 / 5),
          max: 250,
        },
      },
    ],
  },
  elements: {
    point: {
      radius: 0,
      hitRadius: 10,
      hoverRadius: 4,
      hoverBorderWidth: 3,
    },
  },
};

class CityDashboard extends Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.onRadioBtnClick = this.onRadioBtnClick.bind(this);

    this.state = {
      dropdownOpen: false,
      radioSelected: 2,
    };
  }

  toggle() {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen,
    });
  }

  onRadioBtnClick(radioSelected) {
    this.setState({
      radioSelected: radioSelected,
    });
  }

  loading = () => (
    <div className="animated fadeIn pt-1 text-center">Loading...</div>
  );

  render() {
    return (
      <div className="animated fadeIn">
        <Row>
          <Col>
            <Card className="bg-primary">
              <CardHeader>Total</CardHeader>
              <CardBody>
                <Row>
                  <Col xs="12" sm="6" lg="4">
                    <Widget02
                      header="26421"
                      mainText="Petrol Amount (L)"
                      icon="fa fa-cogs"
                      color="primary"
                    />
                  </Col>
                  <Col xs="12" sm="6" lg="4">
                    <Widget02
                      header="134"
                      mainText="Dynamic Changes"
                      icon="fa fa-laptop"
                      color="info"
                    />
                  </Col>
                  <Col xs="12" sm="6" lg="4">
                    <Widget02
                      header="1243"
                      mainText="Containers"
                      icon="fa fa-moon-o"
                      color="warning"
                    />
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>
        <Row>
          <Col>
            <Card className="bg-light-blue">
              <CardHeader>Average</CardHeader>
              <CardBody>
                <Row>
                  <Col xs="12" sm="6" lg="3">
                    <Widget02
                      header="15"
                      mainText="Petrol Amount (L)"
                      icon="fa fa-cogs"
                      color="primary"
                    />
                  </Col>
                  <Col xs="12" sm="6" lg="3">
                    <Widget02
                      header="1.5"
                      mainText="Dynamic Changes"
                      icon="fa fa-laptop"
                      color="info"
                    />
                  </Col>
                  <Col xs="12" sm="6" lg="3">
                    <Widget02
                      header="25"
                      mainText="Containers"
                      icon="fa fa-moon-o"
                      color="warning"
                    />
                  </Col>
                  <Col xs="12" sm="6" lg="3">
                    <Widget02
                      header="45.8"
                      mainText="Time (minutes)"
                      icon="fa fa-moon-o"
                      color="warning"
                    />
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>

        <Row>
          <Col>
            <Card>
              <CardBody>
                <Row>
                  <Col sm="5">
                    <CardTitle className="mb-0">Comparison</CardTitle>
                    <div className="small text-muted">5 April 2020</div>
                  </Col>
                  <Col sm="7" className="d-none d-sm-inline-block">
                    <Button color="primary" className="float-right">
                      <i className="icon-cloud-download"></i>
                    </Button>
                    <ButtonToolbar
                      className="float-right"
                      aria-label="Toolbar with button groups"
                    >
                      <ButtonGroup className="mr-3" aria-label="First group">
                        <Button
                          color="outline-secondary"
                          onClick={() => this.onRadioBtnClick(1)}
                          active={this.state.radioSelected === 1}
                        >
                          Petrol Amount
                        </Button>
                        <Button
                          color="outline-secondary"
                          onClick={() => this.onRadioBtnClick(2)}
                          active={this.state.radioSelected === 2}
                        >
                          Dynamic Changes
                        </Button>
                        <Button
                          color="outline-secondary"
                          onClick={() => this.onRadioBtnClick(3)}
                          active={this.state.radioSelected === 3}
                        >
                          Containers
                        </Button>
                        <Button
                          color="outline-secondary"
                          onClick={() => this.onRadioBtnClick(4)}
                          active={this.state.radioSelected === 4}
                        >
                          Time
                        </Button>
                      </ButtonGroup>
                    </ButtonToolbar>
                  </Col>
                </Row>
                <div
                  className="chart-wrapper"
                  style={{ height: 300 + "px", marginTop: 40 + "px" }}
                >
                  <Line data={mainChart} options={mainChartOpts} height={300} />
                </div>
              </CardBody>
            </Card>
          </Col>
        </Row>

        <Row>
          <Col>
            <Card>
              <CardHeader>Integration Statistics</CardHeader>
              <CardBody>
                <Row>
                  <Col xs="12" md="6" xl="6">
                    <Row>
                      <Col sm="6">
                        <div className="callout callout-info">
                          <small className="text-muted">
                            Integrated Regions
                          </small>
                          <br />
                          <strong className="h4">2</strong>
                          <div className="chart-wrapper">
                            <Line
                              data={makeSparkLineData(0, brandPrimary)}
                              options={sparklineChartOpts}
                              width={100}
                              height={30}
                            />
                          </div>
                        </div>
                      </Col>
                      <Col sm="6">
                        <div className="callout callout-danger">
                          <small className="text-muted">
                            Remaining Regions
                          </small>
                          <br />
                          <strong className="h4">22</strong>
                          <div className="chart-wrapper">
                            <Line
                              data={makeSparkLineData(1, brandDanger)}
                              options={sparklineChartOpts}
                              width={100}
                              height={30}
                            />
                          </div>
                        </div>
                      </Col>
                    </Row>
                    <hr className="mt-0" />
                    <div className="progress-group mb-4">
                      <div className="progress-group-prepend">
                        <span className="progress-group-text">January</span>
                      </div>
                      <div className="progress-group-bars">
                        <Progress
                          className="progress-xs"
                          color="info"
                          value="34"
                        />
                        <Progress
                          className="progress-xs"
                          color="danger"
                          value="78"
                        />
                      </div>
                    </div>
                    <div className="progress-group mb-4">
                      <div className="progress-group-prepend">
                        <span className="progress-group-text">February</span>
                      </div>
                      <div className="progress-group-bars">
                        <Progress
                          className="progress-xs"
                          color="info"
                          value="56"
                        />
                        <Progress
                          className="progress-xs"
                          color="danger"
                          value="94"
                        />
                      </div>
                    </div>
                    <div className="progress-group mb-4">
                      <div className="progress-group-prepend">
                        <span className="progress-group-text">March</span>
                      </div>
                      <div className="progress-group-bars">
                        <Progress
                          className="progress-xs"
                          color="info"
                          value="12"
                        />
                        <Progress
                          className="progress-xs"
                          color="danger"
                          value="67"
                        />
                      </div>
                    </div>
                    <div className="progress-group mb-4">
                      <div className="progress-group-prepend">
                        <span className="progress-group-text">April</span>
                      </div>
                      <div className="progress-group-bars">
                        <Progress
                          className="progress-xs"
                          color="info"
                          value="43"
                        />
                        <Progress
                          className="progress-xs"
                          color="danger"
                          value="91"
                        />
                      </div>
                    </div>
                    <div className="legend text-center">
                      <small>
                        <sup className="px-1">
                          <Badge pill color="info">
                            &nbsp;
                          </Badge>
                        </sup>
                        Integrated Regions &nbsp;
                        <sup className="px-1">
                          <Badge pill color="danger">
                            &nbsp;
                          </Badge>
                        </sup>
                        Remaining Regions
                      </small>
                    </div>
                  </Col>
                  <Col xs="6" md="6" xl="6">
                    <Row>
                      <Col sm="6">
                        <div className="callout callout-success">
                          <small className="text-muted">Utilities</small>
                          <br />
                          <strong className="h4">7</strong>
                          <div className="chart-wrapper">
                            <Line
                              data={makeSparkLineData(2, brandSuccess)}
                              options={sparklineChartOpts}
                              width={100}
                              height={30}
                            />
                          </div>
                        </div>
                      </Col>
                      <Col sm="6">
                        <div className="callout callout-warning">
                          <small className="text-muted">Factories</small>
                          <br />
                          <strong className="h4">8</strong>
                          <div className="chart-wrapper">
                            <Line
                              data={makeSparkLineData(3, brandWarning)}
                              options={sparklineChartOpts}
                              width={100}
                              height={30}
                            />
                          </div>
                        </div>
                      </Col>
                    </Row>
                    <hr className="mt-0" />
                    <ul>
                      <div className="progress-group">
                        <div className="progress-group-header">
                          <i className="icon-user progress-group-icon"></i>
                          <span className="title">Smart garbage</span>
                          <span className="ml-auto font-weight-bold">43%</span>
                        </div>
                        <div className="progress-group-bars">
                          <Progress
                            className="progress-xs"
                            color="success"
                            value="43"
                          />
                        </div>
                      </div>
                      <div className="progress-group">
                        <div className="progress-group-header">
                          <i className="icon-user-female progress-group-icon"></i>
                          <span className="title">ReCycler</span>
                          <span className="ml-auto font-weight-bold">37%</span>
                        </div>
                        <div className="progress-group-bars">
                          <Progress
                            className="progress-xs"
                            color="success"
                            value="37"
                          />
                        </div>
                      </div>
                      <div className="progress-group mb-5">
                        <div className="progress-group-header">
                          <i className="icon-user-female progress-group-icon"></i>
                          <span className="title">Kyiv Garbage</span>
                          <span className="ml-auto font-weight-bold">10%</span>
                        </div>
                        <div className="progress-group-bars">
                          <Progress
                            className="progress-xs"
                            color="success"
                            value="10"
                          />
                        </div>
                      </div>
                    </ul>
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>

        <Row>
          <Col>
            <Table
              hover
              responsive
              className="table-outline mb-0 d-none d-sm-table bg-white"
            >
              <thead className="thead-light">
                <tr>
                  <th>City</th>
                  <th>Population</th>
                  <th className="text-center">Containers</th>
                  <th>Utility</th>
                  <th>Factory</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <div>Desnyanskyi</div>
                    <div className="small text-muted">
                      Registered: Mar 14, 2020
                    </div>
                  </td>
                  <td>
                    <div className="clearfix">
                      <div className="float-left">
                        <strong>20%</strong>
                      </div>
                      <div className="float-right">
                        <small className="text-muted">895,853</small>
                      </div>
                    </div>
                    <Progress className="progress-xs" color="info" value="20" />
                  </td>
                  <td className="text-center">
                    <strong>165</strong>
                  </td>
                  <td>
                    <div>Smart garbage</div>
                    <div className="small text-muted">#1</div>
                  </td>
                  <td>
                    <div>Desnyan</div>
                    <div className="small text-muted">#1</div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <div>Svyatoshinskyi</div>
                    <div className="small text-muted">
                      Registered: Apr 14, 2020
                    </div>
                  </td>
                  <td>
                    <div className="clearfix">
                      <div className="float-left">
                        <strong>18%</strong>
                      </div>
                      <div className="float-right">
                        <small className="text-muted">745,836</small>
                      </div>
                    </div>
                    <Progress className="progress-xs" color="info" value="20" />
                  </td>
                  <td className="text-center">
                    <strong>85</strong>
                  </td>
                  <td>
                    <div>ReCycler</div>
                    <div className="small text-muted">#2</div>
                  </td>
                  <td>
                    <div>Svyatoshyn</div>
                    <div className="small text-muted">#2</div>
                  </td>
                </tr>
              </tbody>
            </Table>
          </Col>
        </Row>
        <br />
      </div>
    );
  }
}

export default CityDashboard;
