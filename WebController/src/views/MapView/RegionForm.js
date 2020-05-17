import React, { Component } from "react";
import {
  Row,
  Card,
  CardHeader,
  CardBody,
  FormGroup,
  Col,
  Label,
  Input,
  FormText,
  Button,
  CardFooter,
  Form,
} from "reactstrap";
import { AppSwitch } from "@coreui/react";

export default class RegionForm extends Component {
  state = {
    utilityCompanies: ["SmartCity", "Recycler", "УкрВідходи"],
    utilityCompany: 0,
    utilities: ["Деснянське", "Печерське", "Дарницьке"],
    utility: 0,
    sortStations: ["Деснянська", "Печерська", "Дарницька"],
    sortStation: 0,
    pickPoints: false,
  };

  render() {
    const {
      utilityCompanies,
      utilityCompany,
      utilities,
      utility,
      sortStations,
      sortStation,
      pickPoints,
    } = this.state;
    return (
      <Row>
        <Col xs="12">
          <Card>
            <CardHeader>
              <strong>Створення</strong> - Регіон
            </CardHeader>
            <CardBody>
              <Form
                action=""
                method="post"
                encType="multipart/form-data"
                className="form-horizontal"
              >
                <FormGroup row>
                  <Col md="3">
                    <Label>Тип</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <p className="form-control-static">Регіон</p>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="text-input">Назва</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input
                      type="text"
                      id="text-input"
                      name="text-input"
                      placeholder="Назва"
                    />
                    <FormText color="muted">Назва регіону</FormText>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="6">
                    <Label htmlFor="text-input">Кількість населення</Label>
                  </Col>
                  <Col xs="12" md="6">
                    <Input
                      type="text"
                      id="text-input"
                      name="text-input"
                      placeholder="Кількість"
                    />
                    <FormText color="success">Необов'язкове поле</FormText>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Комунальне підприємство</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input type="select" name="company" id="company">
                      {utilityCompanies.map((u, index) => (
                        <option
                          value={index.toString()}
                          onClick={() =>
                            this.setState({ utilityCompany: index })
                          }
                        >
                          {u}
                        </option>
                      ))}
                    </Input>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Відділення</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input type="select" name="company" id="company">
                      {utilities.map((u, index) => (
                        <option
                          value={index.toString()}
                          onClick={() => this.setState({ utility: index })}
                        >
                          {u}
                        </option>
                      ))}
                    </Input>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Сортувальна станція</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input type="select" name="sortStation" id="sortStation">
                      {sortStations.map((s, index) => (
                        <option
                          value={index.toString()}
                          onClick={() => this.setState({ sortStation: index })}
                        >
                          {s}
                        </option>
                      ))}
                    </Input>
                  </Col>
                </FormGroup>
                <Card>
                  <CardHeader>Границі регіону</CardHeader>
                  <CardBody>
                    <FormGroup row>
                      <Col md="9">
                        <Label htmlFor="select">Режим встановлення точок</Label>
                      </Col>
                      <Col xs="12" md="3">
                        <AppSwitch
                          className={"mx-1"}
                          variant={"pill"}
                          color={"primary"}
                          checked={pickPoints}
                          onChange={() =>
                            this.setState({ pickPoints: !pickPoints })
                          }
                        />
                      </Col>
                    </FormGroup>
                    <FormGroup row>
                      <Col xs="12">
                        <Button
                          type="submit"
                          size="sm"
                          color="danger"
                          disabled={!pickPoints}
                        >
                          <i className="fa fa-undo"></i> Відмінити останню точку
                        </Button>
                      </Col>
                    </FormGroup>
                    <FormGroup row>
                      <Col xs="12">
                        <Button
                          type="submit"
                          size="sm"
                          color="primary"
                          disabled={!pickPoints}
                        >
                          <i className="fa fa-map-marker"></i> Підтвердити
                          регіон
                        </Button>
                      </Col>
                    </FormGroup>
                  </CardBody>
                </Card>
              </Form>
            </CardBody>
            <CardFooter>
              <Button type="submit" size="sm" color="primary">
                <i className="fa fa-dot-circle-o"></i> Submit
              </Button>
              <Button type="reset" size="sm" color="danger">
                <i className="fa fa-ban"></i> Reset
              </Button>
            </CardFooter>
          </Card>
        </Col>
      </Row>
    );
  }
}
