import React, { Component } from "react";
import {
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  Form,
  FormGroup,
  Label,
  Input,
  Button,
  Row,
  Col,
} from "reactstrap";

class AddItems extends Component {
  state = {
    name: "",
  };

  render() {
    const { name } = this.state;

    return (
      <div className="animated fadeIn">
        <Row>
          <Col xs="4">
            <Card>
              <CardHeader>
                <strong>Комунальне підприємство</strong> Створення
              </CardHeader>
              <CardBody>
                <Form action="" method="post" inline>
                  <FormGroup>
                    <Col xs="3">
                      <Label htmlFor="exampleInputName2">Назва</Label>
                    </Col>
                    <Col xs="9">
                      <Input
                        type="text"
                        placeholder="Назва підприємства"
                        value={name}
                        onChange={(event) =>
                          this.setState({ name: event.target.value })
                        }
                      />
                    </Col>
                  </FormGroup>
                </Form>
              </CardBody>
              <CardFooter>
                <Row>
                  <Col xs="6">
                    <Button
                      size="sm"
                      color="primary"
                      onClick={() => this.createUtilityCompany()}
                    >
                      <i className="fa fa-dot-circle-o"></i> Підтвердити
                    </Button>
                  </Col>
                  <Col xs="6">
                    <Button
                      size="sm"
                      color="danger"
                      onClick={() => this.resetData()}
                    >
                      <i className="fa fa-ban"></i> Перезавантажити
                    </Button>
                  </Col>
                </Row>
              </CardFooter>
            </Card>
          </Col>
        </Row>
      </div>
    );
  }

  resetData() {
    this.setState({ name: "" });
  }

  async createUtilityCompany() {
    const result = await fetch("http://localhost:50398/api/save/region", {
      method: "POST",
      body: JSON.stringify({ name: this.state.name }),
      headers: {
        "Content-Type": "application/json",
      },
    });

    const response = await result.text();
    if (response === "1") {
      this.resetData();
    }
  }
}

export default AddItems;
