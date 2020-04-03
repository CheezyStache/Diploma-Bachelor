import React, { Component } from "react";
import SideHeaderButton from "../../atoms/sideHeader/sideHeaderButton";
import { View } from "react-native";
import { flex } from "../../../styles/mixins";
import headerStyles from "./headerStyles";

export default class Header extends Component {
  render() {
    return (
      <View style={[headerStyles.headerContainer, flex(1)]}>
        <SideHeaderButton iconName="table" text="TABLE" />
      </View>
    );
  }
}
