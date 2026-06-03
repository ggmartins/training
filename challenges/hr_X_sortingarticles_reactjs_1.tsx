import "h8k-components";

import Articles from "./components/Articles";
import React from "react";

import "./App.css";

function App({ articles }) {
  const [articlesData, setArticlesData] = React.useState([...articles].sort((a, b) => b.upvotes - a.upvotes));
  /*React.useEffect(() =>{
    setArticlesData([...articles].sort((a, b) => b.upvotes - a.upvotes))
  }, []);*/

  const handleMostUpvoted = () => {
    setArticlesData([...articlesData].sort((a,b)=> b.upvotes-a.upvotes));
  };

  const handleMostRecent = () => {
    setArticlesData([...articlesData].sort((a,b)=> new Date(b.date)- new Date(a.date)));
  };
  return (
    <>
      <h8k-navbar header="Sorting Articles"></h8k-navbar>
      <div className="App">
        <div className="layout-row align-items-center justify-content-center my-20 navigation">
          <label className="form-hint mb-0 text-uppercase font-weight-light">
            Sort By
          </label>
          <button
            data-testid="most-upvoted-link"
            className="small"
            onClick={handleMostUpvoted}
          >
            Most Upvoted
          </button>
          <button
            data-testid="most-recent-link"
            className="small"
            onClick={handleMostRecent}
          >
            Most Recent
          </button>
        </div>
        <Articles articles={articlesData} />
      </div>
    </>
  );
}

export default App;

///////////

import React from "react";

function ArticleComponent(props) {

  return (
      <tr data-testid="article" key={`${props.id}`}>
            <td data-testid="article-title">{`${props.title}`}</td>
            <td data-testid="article-upvotes">{`${props.upvotes}`}</td>
            <td data-testid="article-date">{`${props.date}`}</td>
      </tr>
  );

};

function Articles({ articles = [] }) {

  return (
    <div className="card w-50 mx-auto">
      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Upvotes</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
            {articles.map((article, i) => {
                //console.log(`${JSON.stringify(article)}`)
                return (<ArticleComponent 
                  id={i} 
                  title={article.title}
                  upvotes={article.upvotes} 
                  date={article.date} 
                />);
            })
          }
        </tbody>
      </table>
    </div>
  );
}

export default Articles;

