import { useState } from "react";
import "./questionnaire.scss";
import axios from "axios";
import Button from "@mui/material/Button";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useStore } from '../../stores/store';

export default function Questionnaire({ handleClose }) {
  const { userStore } = useStore();
  let token = userStore.user.token;
  const [responses, setResponses] = useState({
    shareBelongings: null,
    sleepingHabits: null,
    havingGuests: null,
    roomCleanliness: null,
    studyTime: null,
    studyPlace: null,
    token: token,
  });

  const handleResponseChange = (question, value) => {
    setResponses((prevResponses) => ({
      ...prevResponses,
      [question]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.post(
        "https://localhost:7023/AddQuestionnaire",
        responses
      );
      console.log(response.data);
      toast.success("Pyetësori u ruajt me sukses!");
      handleClose();
    } catch (error) {
      console.error(error);
      toast.error("Pyetësori nuk u ruajt!");
    }
  };

  return (
    <>
      <h2 className="questionnaire-title"></h2>

      <form className="questionnaire-form" onSubmit={handleSubmit}>
        <div className="question-group">
          <p className="question-group-label">
            A i ndani sendet tuaja me të tjerët?
          </p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="shareBelongings"
              value="true"
              checked={responses.shareBelongings === true}
              onChange={(e) =>
                handleResponseChange(
                  "shareBelongings",
                  e.target.value === "true"
                )
              }
            />
            Po
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="shareBelongings"
              value="false"
              checked={responses.shareBelongings === false}
              onChange={(e) =>
                handleResponseChange(
                  "shareBelongings",
                  e.target.value === "true"
                )
              }
            />
            Jo
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">
            Ju jeni:
          </p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="sleepingHabits"
              value="earlyRiser"
              checked={responses.sleepingHabits === "earlyRiser"}
              onChange={(e) =>
                handleResponseChange("sleepingHabits", e.target.value)
              }
            />
            Një person që zgjohet herët
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="sleepingHabits"
              value="nightOwl"
              checked={responses.sleepingHabits === "nightOwl"}
              onChange={(e) =>
                handleResponseChange("sleepingHabits", e.target.value)
              }
            />
            Një person që zgjohet vonë
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">A lejoni mysafirë në dhomën tuaj?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="havingGuests"
              value="true"
              checked={responses.havingGuests === true}
              onChange={(e) =>
                handleResponseChange("havingGuests", e.target.value === "true")
              }
            />
            Po
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="havingGuests"
              value="false"
              checked={responses.havingGuests === false}
              onChange={(e) =>
                handleResponseChange("havingGuests", e.target.value === "true")
              }
            />
            Jo
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">
            Si e vlerësoni pastrimin e dhomës suaj?
          </p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="roomCleanliness"
              value="veryClean"
              checked={responses.roomCleanliness === "veryClean"}
              onChange={(e) =>
                handleResponseChange("roomCleanliness", e.target.value)
              }
            />
            E pastër gjithmonë
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="roomCleanliness"
              value="aLittleMessy"
              checked={responses.roomCleanliness === "aLittleMessy"}
              onChange={(e) =>
                handleResponseChange("roomCleanliness", e.target.value)
              }
            />
            Pak rrëmujë është në rregull
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">
            Sa kohë kaloni duke studiuar?
          </p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="allTheTime"
              checked={responses.studyTime === "allTheTime"}
              onChange={(e) =>
                handleResponseChange("studyTime", e.target.value)
              }
            />
            Gjithë kohën
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="often"
              checked={responses.studyTime === "often"}
              onChange={(e) =>
                handleResponseChange("studyTime", e.target.value)
              }
            />
            Shpesh
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="rarely"
              checked={responses.studyTime === "rarely"}
              onChange={(e) =>
                handleResponseChange("studyTime", e.target.value)
              }
            />
            Rrallë
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">
            Ku preferoni të studioni?
          </p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyPlace"
              value="library"
              checked={responses.studyPlace === "library"}
              onChange={(e) =>
                handleResponseChange("studyPlace", e.target.value)
              }
            />
            Në bibliotekë
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyPlace"
              value="bedroom"
              checked={responses.studyPlace === "bedroom"}
              onChange={(e) =>
                handleResponseChange("studyPlace", e.target.value)
              }
            />
            Në dhomën time
          </label>
        </div>

        <div style={{ display: "flex", justifyContent: "center" }}>
          <Button
            type="submit"
            variant="contained"
            color="primary"
            style={{ borderRadius: "30px", textTransform: "none" }}
          >
            Dërgo
          </Button>
        </div>
      </form>
    </>
  );
}