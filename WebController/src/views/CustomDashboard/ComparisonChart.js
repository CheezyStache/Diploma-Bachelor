import React, { Component } from "react";
import { Line } from "react-chartjs-2";
import {
  Button,
  ButtonGroup,
  ButtonToolbar,
  Card,
  CardBody,
  CardTitle,
  Col,
  Row,
} from "reactstrap";
import { CustomTooltips } from "@coreui/coreui-plugin-chartjs-custom-tooltips";
import { getStyle, hexToRgba } from "@coreui/coreui/dist/js/coreui-utilities";

const brandInfo = getStyle("--info");
const brandDanger = getStyle("--danger");
// Main Chart

//Random Numbers
function random(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

const elements = 30;

const mainChart = (data, labels) => ({
  labels: labels,
  datasets: [
    {
      label: "За датою",
      backgroundColor: hexToRgba(brandInfo, 10),
      borderColor: brandInfo,
      pointHoverBackgroundColor: "#fff",
      borderWidth: 2,
      data: data[0],
    },
    {
      label: "Середньо",
      backgroundColor: "transparent",
      borderColor: brandDanger,
      pointHoverBackgroundColor: "#fff",
      borderWidth: 1,
      borderDash: [8, 5],
      data: data[1],
    },
  ],
});

const mainChartOpts = (max) => ({
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
          stepSize: Math.ceil(max / 5),
          max: max,
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
});

const currentDate = new Date();

let labels = new Array(elements);
for (let i = elements - 1; i >= 0; i--) {
  labels[i] = `${("0" + currentDate.getDate()).slice(-2)}.${(
    "0" +
    (currentDate.getMonth() + 1)
  ).slice(-2)}`;
  currentDate.setDate(currentDate.getDate() - 1);
}

export default class ComparisonChart extends Component {
  constructor(props) {
    super(props);

    this.onRadioBtnClick = this.onRadioBtnClick.bind(this);
  }

  state = {
    radioSelected: 0,
  };

  onRadioBtnClick(radioSelected) {
    this.setState({
      radioSelected: radioSelected,
    });
  }

  render() {
    const { data } = this.props;

    let dataChart = [];
    let dataLine = [];

    for (var i = 0; i <= elements; i++) {
      dataChart.push(
        random(
          data[this.state.radioSelected].average / 2,
          data[this.state.radioSelected].average * 2
        )
      );
      dataLine.push(data[this.state.radioSelected].average);
    }

    return (
      <Card>
        <CardBody>
          <Row>
            <Col sm="5">
              <CardTitle className="mb-0">Порівняння</CardTitle>
              <div className="small text-muted">{`${currentDate.getDate()} ${
                months[currentDate.getMonth()]
              } ${currentDate.getFullYear()}`}</div>
            </Col>
            <Col sm="7" className="d-none d-sm-inline-block">
              <ButtonToolbar
                className="float-right"
                aria-label="Toolbar with button groups"
              >
                <ButtonGroup className="mr-3" aria-label="First group">
                  <Button
                    color="outline-secondary"
                    onClick={() => this.onRadioBtnClick(0)}
                    active={this.state.radioSelected === 0}
                  >
                    Кількість пального
                  </Button>
                  <Button
                    color="outline-secondary"
                    onClick={() => this.onRadioBtnClick(1)}
                    active={this.state.radioSelected === 1}
                  >
                    Динамічні зміни
                  </Button>
                  <Button
                    color="outline-secondary"
                    onClick={() => this.onRadioBtnClick(2)}
                    active={this.state.radioSelected === 2}
                  >
                    Контейнери
                  </Button>
                  <Button
                    color="outline-secondary"
                    onClick={() => this.onRadioBtnClick(3)}
                    active={this.state.radioSelected === 3}
                  >
                    Час
                  </Button>
                </ButtonGroup>
              </ButtonToolbar>
            </Col>
          </Row>
          <div
            className="chart-wrapper"
            style={{ height: 300 + "px", marginTop: 40 + "px" }}
          >
            <Line
              data={mainChart([dataChart, dataLine], labels)}
              options={mainChartOpts(
                Math.ceil(data[this.state.radioSelected].average * 2.4)
              )}
              height={300}
            />
          </div>
        </CardBody>
      </Card>
    );
  }
}

const months = [
  "Січня",
  "Лютого",
  "Березня",
  "Квітня",
  "Травня",
  "Червня",
  "Липня",
  "Серпня",
  "Вересня",
  "Жовтня",
  "Листопада",
  "Грудня",
];
