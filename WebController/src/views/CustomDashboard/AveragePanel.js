import React, { Component } from "react";
import { Card, CardHeader, CardBody, Row, Col } from "reactstrap";
import Widget02 from "../Widgets/Widget02";

export default class AveragePanel extends Component {
  render() {
    const { average } = this.props;

    return (
      <Card className="bg-light-blue">
        <CardHeader>Середньо</CardHeader>
        <CardBody>
          <Row>
            <Col xs="12" sm="6" lg="3">
              <Widget02
                header={average.petrolAmount}
                mainText="Кількість пального (л)"
                icon="fa fa-tint"
                color="success"
              />
            </Col>
            <Col xs="12" sm="6" lg="3">
              <Widget02
                header={average.dynamicChanges}
                mainText="Динамічні зміни"
                icon="fa fa-laptop"
                color="success"
              />
            </Col>
            <Col xs="12" sm="6" lg="3">
              <Widget02
                header={average.containers}
                mainText="Контейнери (зібрано)"
                icon="fa fa-trash"
                color="success"
              />
            </Col>
            <Col xs="12" sm="6" lg="3">
              <Widget02
                header={average.time}
                mainText="Час (хвилини)"
                icon="fa fa-clock-o"
                color="success"
              />
            </Col>
          </Row>
        </CardBody>
      </Card>
    );
  }
}
