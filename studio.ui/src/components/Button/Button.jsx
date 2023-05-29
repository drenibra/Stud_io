import "./button.scss";

//The default values for these buttons are set on intialization
//If you want to give it a different color or class create it on the file you're calling and pass it as a prop
// remember to overwrite them with the !important clause
const Button = ({
  className = "button",
  color = "#c62828",
  text,
  type = "button",
  value,
  onClick,
  disabled = false,
}) => {
  const buttonStyle = {
    backgroundColor: color,
  };

  return (
    <button
      className={className}
      color={color}
      style={buttonStyle}
      type={type}
      value={value}
      onClick={onClick}
      disabled={disabled}
    >
      {text}
    </button>
  );
};

export default Button;
