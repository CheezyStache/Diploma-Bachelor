import React, { Component } from "react";
import { Card, CardBody, Col, Row } from "reactstrap";
import AveragePanel from "../AveragePanel";
import ComparisonChart from "../ComparisonChart";
import ExtraDarkPanel from "../ExtraDarkPanel";

class RegionDashboard extends Component {
  state = {
    average: {
      petrolAmount: 15,
      dynamicChanges: 1.5,
      containers: 25,
      time: 45.8,
    },
    extraInfo: {
      names: [
        "Комунальне підприємство",
        "Комунальне відділення",
        "Сортувальна станція",
      ],
      values: ["Smart garbage", "Деснянське", "Деснянська"],
    },
  };

  render() {
    return (
      <div className="animated fadeIn">
        <Card className="bg-success">
          <CardBody>
            <h2>Деснянський район</h2>
          </CardBody>
        </Card>
        <Row>
          <Col>
            <AveragePanel average={this.state.average} />
          </Col>
        </Row>

        <Row>
          <Col>
            <ComparisonChart
              data={[
                { average: this.state.average.petrolAmount, chartData: [] },
                { average: this.state.average.dynamicChanges, chartData: [] },
                { average: this.state.average.containers, chartData: [] },
                { average: this.state.average.time, chartData: [] },
              ]}
            />
          </Col>
        </Row>

        <Row>
          <Col>
            <ExtraDarkPanel
              names={this.state.extraInfo.names}
              values={this.state.extraInfo.values}
            />
          </Col>
        </Row>
        <br />
      </div>
    );
  }
}

export default RegionDashboard;
