import React from "react";
import { View } from "react-native";
import commonStyles from "../../../styles/common";
import { width, flex } from "../../../styles/mixins";
import { SIDE_HEADER_SIZE } from "../../../styles/sizes";
import mainStyles from "./mainStyles";

const MainScreenTemplate = ({ sideHeader, header }) => {
  return (
    <View style={[commonStyles.row, flex(1)]}>
      <View style={mainStyles.sideHeaderContainer}>{sideHeader}</View>
      <View style={flex(1)}>
        <View style={mainStyles.headerContainer}>{header}</View>
      </View>
    </View>
  );
};

export default MainScreenTemplate;
