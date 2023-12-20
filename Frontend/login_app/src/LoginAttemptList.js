import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = ({ attempts }) => {
  const [filter, setFilter] = useState('');

  const filteredAttempts = attempts.filter((attempt) =>
    attempt.login.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="input"
        placeholder="Filter..."
        value={filter}
        onChange={(e) => setFilter(e.target.value)}
      />
      <ul className="Attempt-List">
        {filteredAttempts.map((attempt, index) => (
          <LoginAttempt key={index}>
            {`${attempt.login} - ${attempt.timestamp}`}
          </LoginAttempt>
        ))}
      </ul>
    </div>
  );
};

export default LoginAttemptList;
