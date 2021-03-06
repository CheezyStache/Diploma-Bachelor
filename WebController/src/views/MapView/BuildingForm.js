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

export default class BuildingForm extends Component {
  state = {
    utility: true,
    positionMap: true,
    utilityCompanies: ["SmartCity", "Recycler", "УкрВідходи"],
    utilityCompany: 0,
    ready: true,
    name: "",
  };

  clearAll() {
    this.setState({ name: "", ready: true, utilityCompany: 0 });
    this.forceUpdate();
  }

  render() {
    const {
      positionMap,
      utility,
      utilityCompanies,
      utilityCompany,
      ready,
      name,
    } = this.state;
    const {
      pickPoint,
      changePickPoint,
      submitPoint,
      addAddress,
      changeAddress,
      submitAddress,
      saveBuilding,
    } = this.props;

    return (
      <Row>
        <Col xs="12">
          <Card>
            <CardHeader>
              <strong>Створення</strong> - Будівля
            </CardHeader>
            <CardBody>
              <Form className="form-horizontal">
                <FormGroup row>
                  <Col md="3">
                    <Label>Тип</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <p className="form-control-static">Будівля</p>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Тип будівлі</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input type="select" name="positionType" id="positionType">
                      <option
                        value="0"
                        onClick={() => this.setState({ utility: true })}
                      >
                        Відділення комунального підприємства
                      </option>
                      <option
                        value="1"
                        onClick={() => this.setState({ utility: false })}
                      >
                        Сортувальна станція
                      </option>
                    </Input>
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
                    <FormText color="muted">{`Назва ${
                      utility ? "відділення" : "станції"
                    }`}</FormText>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Вибір позиції</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input type="select" name="positionType" id="positionType">
                      <option
                        value="0"
                        onClick={() => this.setState({ positionMap: true })}
                      >
                        Мапа
                      </option>
                      <option
                        value="1"
                        onClick={() => this.setState({ positionMap: false })}
                      >
                        Адреса
                      </option>
                    </Input>
                  </Col>
                </FormGroup>
                {positionMap && (
                  <Card>
                    <CardHeader>Точка на мапі</CardHeader>
                    <CardBody>
                      <FormGroup row>
                        <Col md="9">
                          <Label htmlFor="select">
                            Режим встановлення точки
                          </Label>
                        </Col>
                        <Col xs="12" md="3">
                          <AppSwitch
                            className={"mx-1"}
                            variant={"pill"}
                            color={"primary"}
                            checked={pickPoint}
                            onChange={changePickPoint}
                          />
                        </Col>
                      </FormGroup>
                      <FormGroup row>
                        <Col xs="12">
                          <Button
                            size="sm"
                            color="primary"
                            onClick={submitPoint}
                          >
                            <i className="fa fa-map-marker"></i> Підтвердити
                            точку
                          </Button>
                        </Col>
                      </FormGroup>
                    </CardBody>
                  </Card>
                )}
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="select">Адреса</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input
                      type="textarea"
                      placeholder="Адреса"
                      disabled={positionMap}
                      value={addAddress == null ? "" : addAddress}
                      onChange={(event) => changeAddress(event.target.value)}
                    />
                  </Col>
                </FormGroup>
                {!positionMap && (
                  <FormGroup row>
                    <Col xs="12">
                      <Button size="sm" color="primary" onClick={submitAddress}>
                        <i className="fa fa-map-marker"></i> Підтвердити адресу
                      </Button>
                    </Col>
                  </FormGroup>
                )}
                {utility && (
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
                )}
                <FormGroup row>
                  <Col md="9">
                    <Label htmlFor="select">Готовність до роботи</Label>
                  </Col>
                  <Col xs="12" md="3">
                    <AppSwitch
                      className={"mx-1"}
                      variant={"pill"}
                      color={"success"}
                      checked={ready}
                      onChange={() => this.setState({ ready: !ready })}
                    />
                  </Col>
                </FormGroup>
              </Form>
            </CardBody>
            <CardFooter>
              <Button
                size="sm"
                color="primary"
                onClick={() =>
                  saveBuilding(
                    {
                      type: utility ? 0 : 1,
                      name: name,
                      utilityCompany: utility ? utilityCompany + 1 : null,
                      ready: ready,
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
