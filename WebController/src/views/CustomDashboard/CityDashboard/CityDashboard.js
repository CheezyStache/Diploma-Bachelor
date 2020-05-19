import React, { Component } from "react";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Progress,
  Row,
  Table,
} from "reactstrap";
import TotalPanel from "../TotalPanel";
import AveragePanel from "../AveragePanel";
import IntegrationPanelFirst from "../IntegrationPanelFirst";
import IntegrationPanelSecond from "../IntegrationPanelSecond";
import ComparisonChart from "../ComparisonChart";

class CityDashboard extends Component {
  state = {
    radioSelected: 2,
    total: {
      petrolAmount: 26421,
      dynamicChanges: 134,
      containers: 1243,
    },
    average: {
      petrolAmount: 15,
      dynamicChanges: 1.5,
      containers: 25,
      time: 45.8,
    },
    regions: {
      integrated: 8,
      remaining: 22,
      months: [
        { month: "Січень", integrated: 1, remaining: 29 },
        { month: "Лютий", integrated: 2, remaining: 28 },
        { month: "Березень", integrated: 4, remaining: 25 },
        { month: "Квітень", integrated: 8, remaining: 22 },
      ],
    },
    utilities: [
      { month: "Січень", count: 1 },
      { month: "Лютий", count: 2 },
      { month: "Березень", count: 3 },
      { month: "Квітень", count: 5 },
    ],
    utilityCompanies: [
      { name: "Smart garbage", count: 3 },
      { name: "ReCycler", count: 1 },
      { name: "КиївСміття", count: 1 },
    ],
    factories: [
      { month: "Січень", count: 1 },
      { month: "Лютий", count: 1 },
      { month: "Березень", count: 2 },
      { month: "Квітень", count: 3 },
    ],
    regionTable: [
      {
        name: "Деснянський",
        registerDate: "Бер 14, 2020",
        population: "895,853",
        percent: 20,
        containers: 165,
        utility: "Деснянське",
        utilityCompany: "Smart garbage",
        factory: "Деснянська",
      },
      {
        name: "Святошинський",
        registerDate: "Кві 2, 2020",
        population: "745,836",
        percent: 18,
        containers: 85,
        utility: "Святошинське",
        utilityCompany: "ReCycler",
        factory: "Святошин",
      },
    ],
  };

  render() {
    return (
      <div className="animated fadeIn">
        <Card className="bg-success">
          <CardBody>
            <h2>Kyiv</h2>
          </CardBody>
        </Card>
        <Row>
          <Col>
            <TotalPanel total={this.state.total} />
          </Col>
        </Row>
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
            <Card>
              <CardHeader>Статистика інтеграції</CardHeader>
              <CardBody>
                <Row>
                  <Col xs="12" md="6" xl="6">
                    <IntegrationPanelFirst
                      names={["Інтегровані регіони", "Інші регіони"]}
                      items={this.state.regions}
                    />
                  </Col>
                  <Col xs="6" md="6" xl="6">
                    <IntegrationPanelSecond
                      names={["Комунальні відділення", "Сортувальні станції"]}
                      itemsFirst={this.state.utilities}
                      itemsSecond={this.state.factories}
                      barItems={this.state.utilityCompanies}
                      barIcon="icon-user"
                    />
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
                  <th>Регіон</th>
                  <th>Населення</th>
                  <th className="text-center">Контейнери</th>
                  <th>Комунальне відділення</th>
                  <th>Сортувальна станція</th>
                </tr>
              </thead>
              <tbody>
                {this.state.regionTable.map((rt) => (
                  <tr>
                    <td>
                      <div>{rt.name}</div>
                      <div className="small text-muted">
                        Зареєстровано: {rt.registerDate}
                      </div>
                    </td>
                    <td>
                      <div className="clearfix">
                        <div className="float-left">
                          <strong>{rt.percent}%</strong>
                        </div>
                        <div className="float-right">
                          <small className="text-muted">{rt.population}</small>
                        </div>
                      </div>
                      <Progress
                        className="progress-xs"
                        color="info"
                        value={rt.percent}
                      />
                    </td>
                    <td className="text-center">
                      <strong>{rt.containers}</strong>
                    </td>
                    <td>
                      <div>{rt.utility}</div>
                      <div className="small text-muted">
                        {rt.utilityCompany}
                      </div>
                    </td>
                    <td>
                      <div>{rt.factory}</div>
                    </td>
                  </tr>
                ))}
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
