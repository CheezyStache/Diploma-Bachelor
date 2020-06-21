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
import ExtraDarkPanel from "../ExtraDarkPanel";

class CustomDashboard extends Component {
  state = {
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
    cities: {
      integrated: 2,
      remaining: 22,
      months: [
        { month: "Січень", integrated: 1, remaining: 23 },
        { month: "Лютий", integrated: 1, remaining: 23 },
        { month: "Березень", integrated: 2, remaining: 22 },
        { month: "Квітень", integrated: 2, remaining: 22 },
      ],
    },
    integratedRegions: [
      { month: "Січень", count: 532 },
      { month: "Лютий", count: 893 },
      { month: "Березень", count: 1256 },
      { month: "Квітень", count: 9483 },
    ],
    remainingRegions: [
      { month: "Січень", count: 48088 },
      { month: "Лютий", count: 47727 },
      { month: "Березень", count: 47364 },
      { month: "Квітень", count: 39137 },
    ],
    regionStatistics: [
      {
        name: "Інтегровані регіони",
        count: 9483,
        successColor: true,
        total: 48620,
      },
      { name: "Інші регіони", count: 39137, total: 48620 },
    ],
    extraInfo: {
      names: [
        "Комунальні підприємства",
        "Комунальні відділення",
        "Сортувальні станції",
      ],
      values: ["25", "134", "12434"],
      icons: ["fa-building", "fa-building-o", "fa-industry"],
    },
    cityTable: [
      {
        name: "Київ",
        registerDate: "Січ 5, 2020",
        population: "2,654,645",
        percent: 15,
        containers: 4632,
        regions: 25,
        emblem: "kyiv.png",
      },
      {
        name: "Львів",
        registerDate: "Бер 23, 2020",
        population: "1,844,345",
        percent: 10,
        containers: 1475,
        regions: 16,
        emblem: "lviv.png",
      },
    ],
  };

  render() {
    return (
      <div className="animated fadeIn">
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
                      names={["Інтегровані міста", "Інші міста"]}
                      items={this.state.cities}
                    />
                  </Col>
                  <Col xs="6" md="6" xl="6">
                    <IntegrationPanelSecond
                      names={["Інтегровані регіони", "Інші регіони"]}
                      itemsFirst={this.state.integratedRegions}
                      itemsSecond={this.state.remainingRegions}
                      barItems={this.state.regionStatistics}
                      barIcon="fa fa-map-o"
                    />
                  </Col>
                </Row>
              </CardBody>
            </Card>
          </Col>
        </Row>

        <Row>
          <Col>
            <ExtraDarkPanel
              names={this.state.extraInfo.names}
              values={this.state.extraInfo.values}
              icons={this.state.extraInfo.icons}
            />
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
                  <th className="text-center">Емблема</th>
                  <th>Місто</th>
                  <th>Населення</th>
                  <th className="text-center">Регіони</th>
                  <th className="text-center">Контейнери</th>
                </tr>
              </thead>
              <tbody>
                {this.state.cityTable.map((ct) => (
                  <tr>
                    <td className="text-center">
                      <div className="avatar">
                        <img
                          src={"assets/img/avatars/" + ct.emblem}
                          className="img-avatar"
                          alt="emblem"
                        />
                      </div>
                    </td>
                    <td>
                      <div>{ct.name}</div>
                      <div className="small text-muted">
                        Зареєстровано: {ct.registerDate}
                      </div>
                    </td>
                    <td>
                      <div className="clearfix">
                        <div className="float-left">
                          <strong>{ct.percent}%</strong>
                        </div>
                        <div className="float-right">
                          <small className="text-muted">{ct.population}</small>
                        </div>
                      </div>
                      <Progress
                        className="progress-xs"
                        color="info"
                        value={ct.percent}
                      />
                    </td>
                    <td className="text-center">
                      <strong>{ct.regions}</strong>
                    </td>
                    <td className="text-center">
                      <strong>{ct.containers}</strong>
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

export default CustomDashboard;
