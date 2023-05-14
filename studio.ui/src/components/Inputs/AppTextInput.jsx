import { TextField } from "@mui/material";
import { useController } from "react-hook-form";

export default function AppTextInput(props) {
  const { field } = useController(props);

  return (
    <TextField
      {...props}
      {...field}
      multiline={props.multiline}
      rows={props.rows}
      type={props.type}
      fullWidth
      variant="outlined"
      error={!!field.fieldState.error}
      helperText={field.fieldState.error?.message}
    />
  );
}
