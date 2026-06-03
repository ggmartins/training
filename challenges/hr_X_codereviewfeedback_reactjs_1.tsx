import React from "react";

const CRVoteComponent = (props) => {
  const [upvotes, setUpVotes] = React.useState(0);
  const [dwvotes, setDownVotes] = React.useState(0);
  const id = props.id;
  function clickUp() {
    setUpVotes(upvotes + props.voteW);
  }

  function clickDw() {
    setDownVotes(dwvotes + props.voteW);
  }

  return (
    <div className="my-0 mx-auto text-center w-mx-1200">
      <div className="flex wrap justify-content-center mt-30 gap-30">
        <div className="pa-10 w-300 card">
          <h2>{props.name}</h2>
          <div className="flex my-30 mx-0 justify-content-around">
            <button className="py-10 px-15" data-testid={`upvote-btn-${id}`} onClick={clickUp}>
              👍 Upvote
            </button>
            <button className="py-10 px-15 danger" data-testid={`downvote-btn-${id}`} onClick={clickDw}>
              👎 Downvote
            </button>
          </div>
          <p className="my-10 mx-0" data-testid={`upvote-count-${id}`}>
            Upvotes: <strong>{upvotes}</strong>
          </p>
          <p className="my-10 mx-0" data-testid={`downvote-count-${id}`}>
            Downvotes: <strong>{dwvotes}</strong>
          </p>
        </div>
      </div>
    </div>
  );
};


const FeedbackSystem = () => {
  const criteriaList = [
  { name: "Readability", voteW: 1 },
  { name: "Performance", voteW: 1 },
  { name: "Security", voteW: 1 },
  { name: "Documentation", voteW: 1 },
  { name: "Testing", voteW: 1 }
];

  return (
    <div className="flex my-30 mx-0 justify-content-around">
      {criteriaList.map((criteria, i) => (
        <CRVoteComponent 
          id={i} 
          name={criteria.name} 
          voteW={criteria.voteW} 
        />
      ))}
    </div>
  );
};

export default FeedbackSystem;

