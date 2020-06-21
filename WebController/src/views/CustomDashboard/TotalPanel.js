import React, { Component } from "react";
import { Card, CardHeader, CardBody, Row, Col } from "reactstrap";
import Widget02 from "../Widgets/Widget02";

export default class TotalPanel extends Component {
  render() {
    const { total } = this.props;

    return (
      <Card className="bg-primary">
        <CardHeader>Загально</CardHeader>
        <CardBody>
          <Row>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={total.petrolAmount}
                mainText="Кількість пального (л)"
                icon="fa fa-tint"
                color="primary"
              />
            </Col>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={total.dynamicChanges}
                mainText="Динамічні зміни"
                icon="fa fa-laptop"
                color="primary"
              />
            </Col>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={total.containers}
                mainText="Контейнери"
                icon="fa fa-trash"
                color="primary"
              />
            </Col>
          </Row>
        </CardBody>
      </Card>
    );
  }
}
