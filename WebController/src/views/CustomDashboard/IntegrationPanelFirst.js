import React, { Component } from "react";
import { Line } from "react-chartjs-2";
import { Badge, Col, Progress, Row } from "reactstrap";
import { CustomTooltips } from "@coreui/coreui-plugin-chartjs-custom-tooltips";
import { getStyle } from "@coreui/coreui/dist/js/coreui-utilities";

const brandPrimary = getStyle("--primary");
const brandDanger = getStyle("--danger");

const makeSparkLineData = (dataSet, dataLabels, label, variant) => {
  console.log(dataSet, dataLabels, label);
  const data = {
    labels: dataLabels,
    datasets: [
      {
        backgroundColor: "transparent",
        borderColor: variant ? variant : "#c2cfd6",
        data: dataSet,
        label: label,
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

export default class IntegrationPanelFirst extends Component {
  render() {
    const { names, items } = this.props;

    return (
      <div>
        <Row>
          <Col sm="6">
            <div className="callout callout-info">
              <small className="text-muted">{names[0]}</small>
              <br />
              <strong className="h4">{items.integrated}</strong>
              <div className="chart-wrapper">
                <Line
                  data={makeSparkLineData(
                    items.months.map((m) => m.integrated),
                    items.months.map((m) => m.month),
                    names[0],
                    brandPrimary
                  )}
                  options={sparklineChartOpts}
                  width={100}
                  height={30}
                />
              </div>
            </div>
          </Col>
          <Col sm="6">
            <div className="callout callout-danger">
              <small className="text-muted">{names[1]}</small>
              <br />
              <strong className="h4">{items.remaining}</strong>
              <div className="chart-wrapper">
                <Line
                  data={makeSparkLineData(
                    items.months.map((m) => m.remaining),
                    items.months.map((m) => m.month),
                    names[1],
                    brandDanger
                  )}
                  options={sparklineChartOpts}
                  width={100}
                  height={30}
                />
              </div>
            </div>
          </Col>
        </Row>
        <hr className="mt-0" />
        {items.months.map((m) => (
          <div className="progress-group mb-4">
            <div className="progress-group-prepend">
              <span className="progress-group-text">{m.month}</span>
            </div>
            <div className="progress-group-bars">
              <Progress
                className="progress-xs"
                color="info"
                value={(m.integrated / (m.integrated + m.remaining)) * 100}
              />
              <Progress
                className="progress-xs"
                color="danger"
                value={(m.remaining / (m.integrated + m.remaining)) * 100}
              />
            </div>
          </div>
        ))}
        <div className="legend text-center">
          <small>
            <sup className="px-1">
              <Badge pill color="info">
                &nbsp;
              </Badge>
            </sup>
            {names[0]} &nbsp;
            <sup className="px-1">
              <Badge pill color="danger">
                &nbsp;
              </Badge>
            </sup>
            {names[1]}
          </small>
        </div>
      </div>
    );
  }
}
