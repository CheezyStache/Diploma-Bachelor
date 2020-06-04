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
    utilityCompanies: [
      { name: "SmartCity", id: 1 },
      { name: "Recycler", id: 2 },
      { name: "УкрВідходи", id: 3 },
    ],
    utilityCompany: 0,
    utilities: [
      { name: "Деснянське", id: 1 },
      { name: "Печерське", id: 2 },
      { name: "Печерське", id: 3 },
    ],
    utility: 0,
    sortStations: [
      { name: "Деснянська", id: 1 },
      { name: "Печерська", id: 2 },
      { name: "Печерська", id: 3 },
    ],
    sortStation: 1,
    name: "",
    population: null,
  };

  clearAll() {
    this.setState({
      name: "",
      population: null,
      utilityCompany: this.state.utilityCompanies[0]
        ? this.state.utilityCompanies[0].id
        : -1,
      utility: this.state.utilities[0] ? this.state.utilities[0].id : -1,
      sortStation: this.state.sortStations[0]
        ? this.state.sortStations[0].id
        : -1,
    });
    this.forceUpdate();
  }

  componentDidMount() {
    fetch("http://localhost:50398/api/map/utilityCompany").then((response) => {
      return response.json().then((result) =>
        this.setState({
          utilityCompanies: result,
          utilityCompany: result[0] ? result[0].id : -1,
        })
      );
    });
    fetch("http://localhost:50398/api/map/utilities/1").then((response) => {
      return response.json().then((result) =>
        this.setState({
          utilities: result,
          utility: result[0] ? result[0].id : -1,
        })
      );
    });
    fetch("http://localhost:50398/api/map/factories").then((response) => {
      return response.json().then((result) =>
        this.setState({
          sortStations: result,
          sortStation: result[0] ? result[0].id : -1,
        })
      );
    });
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevState.utilityCompany !== this.state.utilityCompany) {
      fetch(
        "http://localhost:50398/api/map/utilities/" + this.state.utilityCompany
      ).then((response) => {
        return response.json().then((result) =>
          this.setState({
            utilities: result,
            utility: result[0] ? result[0].id : -1,
          })
        );
      });
    }
  }

  render() {
    const {
      utilityCompanies,
      utilityCompany,
      utilities,
      utility,
      sortStation,
      name,
      population,
      sortStations,
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
                      {utilityCompanies.map((u) => (
                        <option
                          value={u.id.toString()}
                          onClick={() =>
                            this.setState({ utilityCompany: u.id })
                          }
                        >
                          {u.name}
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
                      {utilities.map((u) => (
                        <option
                          value={u.id.toString()}
                          onClick={() => this.setState({ utility: u.id })}
                        >
                          {u.name}
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
                      {sortStations.map((s) => (
                        <option
                          value={s.id.toString()}
                          onClick={() => this.setState({ sortStation: s.id })}
                        >
                          {s.name}
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
                      utility: utility,
                      sortStation: sortStation,
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
