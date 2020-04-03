import React, { Component } from "react";
import { View } from "react-native";
import SideHeader from "../../components/molecules/sideHeader/sideHeader";
import MainScreenTemplate from "../../components/templates/Main/mainScreenTemplate";
import Header from "../../components/molecules/header/header";

export default class MainScreen extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <MainScreenTemplate sideHeader={<SideHeader />} header={<Header />} />
    );
  }
}
