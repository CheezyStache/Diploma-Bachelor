import { StyleSheet } from "react-native";
import { SIDE_HEADER_SIZE, HEADER_SIZE } from "../../../styles/sizes";

const mainStyles = StyleSheet.create({
  sideHeaderContainer: {
    height: "100%",
    width: SIDE_HEADER_SIZE
  },
  headerContainer: {
    width: "100%",
    height: HEADER_SIZE
  }
});

export default mainStyles;
