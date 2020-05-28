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

export default class RegionForm extends Component {
  state = {
    utilityCompanies: ["SmartCity", "Recycler", "УкрВідходи"],
    utilityCompany: 0,
    utilities: ["Деснянське", "Печерське", "Дарницьке"],
    utility: 0,
    sortStations: ["Деснянська", "Печерська", "Дарницька"],
    sortStation: 0,
    name: "",
    population: null,
  };

  clearAll() {
    this.setState({
      name: "",
      population: null,
      utilityCompany: 0,
      utility: 0,
      sortStation: 0,
    });
    this.forceUpdate();
  }

  render() {
    const {
      utilityCompanies,
      utilityCompany,
      utilities,
      utility,
      sortStations,
      sortStation,
      name,
      population,
    } = this.state;
    const { saveRegion, resetRegion } = this.props;

    return (
      <Row>
        <Col xs="12">
          <Card>
            <CardHeader>
              <strong>Створення</strong> - Регіон
            </CardHeader>
            <CardBody>
              <Form className="form-horizontal">
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
                      name="text-input"
                      placeholder="Назва"
                      value={name}
                      onChange={(event) =>
                        this.setState({ name: event.target.value })
                      }
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
                      name="text-input"
                      placeholder="Кількість"
                      value={population == null ? "" : population}
                      onChange={(event) =>
                        this.setState({ population: event.target.value })
                      }
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
                            this.setState({ utilityCompany: index + 1 })
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
                <FormGroup row>
                  <Col xs="12">
                    <Button size="sm" color="danger" onClick={resetRegion}>
                      <i className="fa fa-map-marker"></i> Перезавантажити
                      регіон
                    </Button>
                  </Col>
                </FormGroup>
              </Form>
            </CardBody>
            <CardFooter>
              <Button
                size="sm"
                color="primary"
                onClick={() =>
                  saveRegion(
                    {
                      name: name,
                      population: parseInt(population),
                      utility: utility + 1,
                      sortStation: sortStation + 1,
                    },
                    () => this.clearAll()
                  )
                }
              >
                <i className="fa fa-dot-circle-o"></i> Submit
              </Button>
            </CardFooter>
          </Card>
        </Col>
      </Row>
    );
  }
}
