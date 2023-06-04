import React, { useState } from 'react';
import './questionnaire.scss';
import axios from 'axios';
import Button from "@mui/material/Button";


export default function Questionnaire() {
  const [responses, setResponses] = useState({
    shareBelongings: null,
    sleepingHabits: null,
    havingGuests: null,
    roomCleanliness: null,
    studyTime: null,
    studyPlace: null,
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
      const response = await axios.post('https://localhost:7023/AddQuestionnaire', responses);
      console.log(response.data);      
      alert('Questionnaire submitted successfully!');
    } catch (error) {
      console.error(error);
      alert('An error occurred while submitting the questionnaire. Please try again later.');
    }
  };
  

  return (
    <>
      <h2 className="questionnaire-title"></h2>

      <form className="questionnaire-form" onSubmit={handleSubmit}>
        <div className="question-group">
          <p className="question-group-label">Do you share your belongings with others?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="shareBelongings"
              value="true"
              checked={responses.shareBelongings === true}
              onChange={(e) => handleResponseChange('shareBelongings', e.target.value === 'true')}
            />
            Yes
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="shareBelongings"
              value="false"
              checked={responses.shareBelongings === false}
              onChange={(e) => handleResponseChange('shareBelongings', e.target.value === 'true')}
            />
            No
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">Select your sleeping habits:</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="sleepingHabits"
              value="earlyRiser"
              checked={responses.sleepingHabits === 'earlyRiser'}
              onChange={(e) => handleResponseChange('sleepingHabits', e.target.value)}
            />
            Early Riser
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="sleepingHabits"
              value="nightOwl"
              checked={responses.sleepingHabits === 'nightOwl'}
              onChange={(e) => handleResponseChange('sleepingHabits', e.target.value)}
            />
            Night Owl
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">Do you allow guests in your room?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="havingGuests"
              value="true"
              checked={responses.havingGuests === true}
              onChange={(e) => handleResponseChange('havingGuests', e.target.value === 'true')}
            />
            Yes
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="havingGuests"
              value="false"
              checked={responses.havingGuests === false}
              onChange={(e) => handleResponseChange('havingGuests', e.target.value === 'true')}
            />
            No
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">How would you rate your room cleanliness?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="roomCleanliness"
              value="veryClean"
              checked={responses.roomCleanliness === 'veryClean'}
              onChange={(e) => handleResponseChange('roomCleanliness', e.target.value)}
            />
            Clean at all times
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="roomCleanliness"
              value="aLittleMessy"
              checked={responses.roomCleanliness === 'aLittleMessy'}
              onChange={(e) => handleResponseChange('roomCleanliness', e.target.value)}
            />
            A little messy is okay
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">How much time do you spend studying?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="allTheTime"
              checked={responses.studyTime === 'allTheTime'}
              onChange={(e) => handleResponseChange('studyTime', e.target.value)}
            />
            All the time
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="often"
              checked={responses.studyTime === 'often'}
              onChange={(e) => handleResponseChange('studyTime', e.target.value)}
            />
            Often
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyTime"
              value="rarely"
              checked={responses.studyTime === 'rarely'}
              onChange={(e) => handleResponseChange('studyTime', e.target.value)}
            />
            Rarely
          </label>
        </div>

        <div className="question-group">
          <p className="question-group-label">Where do you prefer to study?</p>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyPlace"
              value="library"
              checked={responses.studyPlace === 'library'}
              onChange={(e) => handleResponseChange('studyPlace', e.target.value)}
            />
            At Library
          </label>
          <label className="answer-option">
            <input
              type="radio"
              className="radio-custom"
              name="studyPlace"
              value="bedroom"
              checked={responses.studyPlace === 'bedroom'}
              onChange={(e) => handleResponseChange('studyPlace', e.target.value)}
            />
            In Room
          </label>
        </div>

        <div style={{ display: 'flex', justifyContent: 'center' }}>
        <Button
        type="submit"
        variant="contained"
        color="primary"
        style={{ borderRadius: '30px', textTransform: 'none' }}
      >
        Submit
      </Button>

        </div>
      </form>
    </>
  );
}
