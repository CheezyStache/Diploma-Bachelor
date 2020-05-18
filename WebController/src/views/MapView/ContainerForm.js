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

export default class ContainerForm extends Component {
  state = {
    positionMap: true,
  };

  render() {
    const { positionMap } = this.state;

    const {
      pickPoint,
      changePickPoint,
      submitPoint,
      addAddress,
      changeAddress,
      submitAddress,
    } = this.props;
    return (
      <Row>
        <Col xs="12">
          <Card>
            <CardHeader>
              <strong>Створення</strong> - Контейнер
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
                    <p className="form-control-static">Контейнер</p>
                  </Col>
                </FormGroup>
                <FormGroup row>
                  <Col md="3">
                    <Label htmlFor="text-input">Код датчика</Label>
                  </Col>
                  <Col xs="12" md="9">
                    <Input
                      type="text"
                      id="text-input"
                      name="text-input"
                      placeholder="Код"
                    />
                    <FormText color="muted">12-значний код</FormText>
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
                      id="addressInput"
                      placeholder="Адреса"
                      disabled={positionMap}
                      value={addAddress}
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
