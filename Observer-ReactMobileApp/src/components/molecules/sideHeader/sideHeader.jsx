import React, { Component } from "react";
import SideHeaderButton from "../../atoms/sideHeader/sideHeaderButton";
import { View } from "react-native";
import { flex } from "../../../styles/mixins";
import sideHeaderStyles from "./sideHeaderStyles";

export default class SideHeader extends Component {
  render() {
    return (
      <View style={[sideHeaderStyles.headerContainer, flex(1)]}>
        <SideHeaderButton iconName="table" text="TABLE" />
      </View>
    );
  }
}
