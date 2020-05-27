import React, { Component } from "react";
import { Card, CardBody, Row, Col } from "reactstrap";
import Widget02 from "../Widgets/Widget02";

export default class ExtraDarkPanel extends Component {
  render() {
    const { names, values } = this.props;

    return (
      <Card className="bg-gray-700">
        <CardBody>
          <Row>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={values[0]}
                mainText={names[0]}
                icon="fa fa-cogs"
                color="primary"
                variant="2"
              />
            </Col>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={values[1]}
                mainText={names[1]}
                icon="fa fa-laptop"
                color="success"
                variant="2"
              />
            </Col>
            <Col xs="12" sm="6" lg="4">
              <Widget02
                header={values[2]}
                mainText={names[2]}
                icon="fa fa-moon-o"
                color="warning"
                variant="2"
              />
            </Col>
          </Row>
        </CardBody>
      </Card>
    );
  }
}
