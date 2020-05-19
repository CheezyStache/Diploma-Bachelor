import React, { Component } from "react";
import { Line } from "react-chartjs-2";
import { Col, Progress, Row } from "reactstrap";
import { CustomTooltips } from "@coreui/coreui-plugin-chartjs-custom-tooltips";
import { getStyle } from "@coreui/coreui/dist/js/coreui-utilities";

const brandSuccess = getStyle("--success");
const brandWarning = getStyle("--warning");

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

export default class IntegrationPanelSecond extends Component {
  render() {
    const { names, itemsFirst, itemsSecond, barItems, barIcon } = this.props;

    return (
      <div>
        <Row>
          <Col sm="6">
            <div className="callout callout-success">
              <small className="text-muted">{names[0]}</small>
              <br />
              <strong className="h4">
                {itemsFirst[itemsFirst.length - 1].count}
              </strong>
              <div className="chart-wrapper">
                <Line
                  data={makeSparkLineData(
                    itemsFirst.map((m) => m.count),
                    itemsFirst.map((m) => m.month),
                    names[0],
                    brandSuccess
                  )}
                  options={sparklineChartOpts}
                  width={100}
                  height={30}
                />
              </div>
            </div>
          </Col>
          <Col sm="6">
            <div className="callout callout-warning">
              <small className="text-muted">{names[1]}</small>
              <br />
              <strong className="h4">
                {itemsSecond[itemsSecond.length - 1].count}
              </strong>
              <div className="chart-wrapper">
                <Line
                  data={makeSparkLineData(
                    itemsSecond.map((m) => m.count),
                    itemsSecond.map((m) => m.month),
                    names[1],
                    brandWarning
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
        <ul>
          {barItems.map((bi) => (
            <div className="progress-group">
              <div className="progress-group-header">
                <i className={barIcon + " progress-group-icon"}></i>
                <span className="title">{bi.name}</span>
                <span className="ml-auto font-weight-bold">
                  {Math.round(
                    (bi.count / itemsFirst[itemsFirst.length - 1].count) * 100
                  ) + "%"}
                </span>
              </div>
              <div className="progress-group-bars">
                <Progress
                  className="progress-xs"
                  color="success"
                  value={
                    (bi.count / itemsFirst[itemsFirst.length - 1].count) * 100
                  }
                />
              </div>
            </div>
          ))}
        </ul>
      </div>
    );
  }
}
