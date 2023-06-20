import React, { useState } from 'react';
import agent from '../../../api/study-group-agents';
import TextField from '@mui/material/TextField';
import { CircularProgress } from '@mui/material';
import Button from '@mui/material/Button';

const ChatComponent = () => {
  const [inputValue, setInputValue] = useState('');
  const [loading, setLoading] = useState(false);
  const [messages, setMessages] = useState([]);

  const handleInputChange = (event) => {
    setInputValue(event.target.value);
  };

  const handleSendMessage = async () => {
    if (inputValue.trim() === '') {
      return;
    }

    setLoading(true);

    try {
      const response = await agent.StudyGroups.studyGPT(inputValue + ' respond in albanian');
      setMessages((prevMessages) => [...prevMessages, { text: inputValue, isUser: true }, { text: response, isUser: false }]);
    } catch (error) {
      console.error('Error:', error);
    } finally {
      setLoading(false);
      setInputValue('');
    }
  };

  return (
    <div style={{ display: 'flex', backgroundColor: '#d7d7d7', padding: '16px', flexDirection: 'column', height: '50vh', marginBottom: '30px', borderRadius: '8px' }}>
      <div style={{ overflow: 'hidden', display: 'flex', flexDirection: 'column', flexGrow: 1, overflow: 'hidden', marginBottom: '16px' }}>
        <div style={{ display: 'flex', flexDirection: 'column', position: 'relative', right: '-25px', overflowY: 'scroll', flex: 1 }}>
          {messages.map((message, index) => (
            <div
              key={index}
              style={{
                display: 'flex',
                backgroundColor: message.isUser ? '#BF1A2F' : '#FFFFFF',
                borderRadius: '4px',
                padding: '8px',
                textAlign: 'left',
                marginBottom: '8px',
                alignSelf: message.isUser ? 'flex-end' : 'flex-start',
                maxWidth: '70%',
                color: message.isUser ? '#FFFFFF' : 'inherit',
              }}
            >
              {message.text}
            </div>
          ))}
        </div>
        {loading && <CircularProgress />}
      </div>
      <div style={{ display: 'flex', alignItems: 'center' }}>
        <TextField style={{ marginRight: '16px', flexGrow: 1 }} value={inputValue} onChange={handleInputChange} placeholder="Type a message" variant="outlined" />
        <Button variant="contained" onClick={handleSendMessage}>
          Send
        </Button>
      </div>
    </div>
  );
};

export default ChatComponent;
