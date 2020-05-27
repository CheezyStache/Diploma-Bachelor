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
    const { saveRegion } = this.props;

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
              </Form>
            </CardBody>
            <CardFooter>
              <Button
                size="sm"
                color="primary"
                onClick={() =>
                  saveRegion({
                    name: name,
                    population: parseInt(population),
                    utility: utility,
                    sortStation: sortStation,
                  })
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
