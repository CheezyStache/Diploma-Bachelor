import React from "react";
import { View, Text } from "react-native";
import { TouchableOpacity } from "react-native-gesture-handler";
import { flex } from "../../../styles/mixins";
import { AntDesign } from "@expo/vector-icons";
import { WHITE } from "../../../styles/colors";
import commonStyles from "../../../styles/common";
import sideHeaderStyles from "./sideHeaderStyles";

const SideHeaderButton = ({ iconName, text, onPress }) => {
  const iconSize = 36;

  return (
    <View style={sideHeaderStyles.buttonContainer}>
      <TouchableOpacity onPress={onPress}>
        <View style={sideHeaderStyles.buttonContainer}>
          <View style={[commonStyles.centerContainer, flex(2)]}>
            <AntDesign name={iconName} size={iconSize} color={WHITE} />
          </View>
          <View style={[commonStyles.centerContainer, flex(1)]}>
            <Text style={sideHeaderStyles.buttonText}>{text}</Text>
          </View>
        </View>
      </TouchableOpacity>
    </View>
  );
};

export default SideHeaderButton;
