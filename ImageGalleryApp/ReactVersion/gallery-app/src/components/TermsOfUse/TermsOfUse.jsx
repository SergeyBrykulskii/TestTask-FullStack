import React from 'react';

const TermsOfUse = ({ termsOfUse, onAccept }) => {
  return (
    <div className="terms-of-use">
      <h1>Terms of Use</h1>
      <div className="terms-content">
        {termsOfUse.paragraphs.map((paragraph) => (
          <div key={paragraph.index}>
            <h3>{paragraph.title}</h3>
            <p>{paragraph.content || paragraph.text}</p>
          </div>
        ))}
      </div>
      <button className="accept-button" onClick={onAccept}>
        Accept
      </button>
    </div>
  );
};

export default TermsOfUse;
