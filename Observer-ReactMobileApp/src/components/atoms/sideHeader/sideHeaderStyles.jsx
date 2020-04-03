import { StyleSheet } from "react-native";
import { WHITE, BLACK } from "../../../styles/colors";
import { SIDE_HEADER_BUTTON_SIZE } from "../../../styles/sizes";

const sideHeaderStyles = StyleSheet.create({
  buttonContainer: {
    height: SIDE_HEADER_BUTTON_SIZE,
    width: SIDE_HEADER_BUTTON_SIZE
  },
  buttonText: {
    fontSize: 20,
    color: WHITE
  }
});

export default sideHeaderStyles;
