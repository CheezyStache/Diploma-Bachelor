import React from "react";
import containerGreen from "../../assets/img/container-green.png";
import containerRed from "../../assets/img/container-red.png";
import utilityGreen from "../../assets/img/utility-green.png";
import utilityRed from "../../assets/img/utility-red.png";
import factoryGreen from "../../assets/img/factory-green.png";
import factoryRed from "../../assets/img/factory-red.png";
import addMarker from "../../assets/img/add-marker.png";

const markerCenterStyle = {
  width: "40px",
  height: "40px",
  marginLeft: "-20px",
  marginTop: "-40px",
};

export const ContainerMarker = ({ status }) => {
  return (
    <img
      src={status ? containerGreen : containerRed}
      style={markerCenterStyle}
    />
  );
};

export const UtilityMarker = ({ status }) => {
  return (
    <img src={status ? utilityGreen : utilityRed} style={markerCenterStyle} />
  );
};

export const FactoryMarker = ({ status }) => {
  return (
    <img src={status ? factoryGreen : factoryRed} style={markerCenterStyle} />
  );
};

export const AddMarker = () => {
  return (
    <img
      src={addMarker}
      style={{
        width: "40px",
        height: "40px",
        marginLeft: "-20px",
        marginTop: "-40px",
      }}
    />
  );
};
