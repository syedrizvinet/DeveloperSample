import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = (props) => {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();

    // Check if login and password are not empty before submitting
    if (login.trim() !== '' && password.trim() !== '') {
      props.onSubmit({
        login: login,
        password: password,
      });

      // Clear the form after submission
      setLogin('');
      setPassword('');
    }
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input
        type="text"
        id="name"
        value={login}
        onChange={(e) => setLogin(e.target.value)}
      />
      <label htmlFor="password">Password</label>
      <input
        type="password"
        id="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit">Continue</button>
    </form>
  );
};

export default LoginForm;
