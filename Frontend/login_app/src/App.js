import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);

  const handleLoginSubmit = ({ login, password }) => {
    // Assuming successful login, update the loginAttempts state
    setLoginAttempts((prevAttempts) => [
      ...prevAttempts,
      { login, timestamp: new Date().toLocaleString() },
    ]);
  };

  return (
    <div className="App">
      <LoginForm onSubmit={handleLoginSubmit} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
