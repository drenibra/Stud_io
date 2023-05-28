import { Children } from "react";
import "./form-components.scss";
export const Input = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <input
        required={props.required}
        name={props.name}
        placeholder={props.placeholder}
        type={props.type}
        onChange={props.onChange}
      />
    </div>
  );
};

export const Select = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <select onChange={props.onChange} name={props.name} required>
        <option value="">Zgjedh</option>
        {Children.toArray(
          props?.objects?.map((object) => (
            <option value={object?.id}>{object[props.objectName]}</option>
          ))
        )}
      </select>
    </div>
  );
};

export const SelectBool = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <select onChange={props.onChange} name={props.name} required>
        <option value="">Zgjedh</option>
        <option name={props.name} value={true}>
          Po
        </option>
        <option value={false}>Jo</option>
      </select>
    </div>
  );
};
