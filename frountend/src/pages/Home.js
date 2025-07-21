
import React from 'react';
import { Link } from 'react-router-dom';
function Home() {
  return (
    <div className="container mt-5"> {/* 直接使用 Bootstrap classes */}
      <div className="row">
        <div className="col-md-8">
          <header className="text-center mb-4">
            <h1 className="text-primary">歡迎來到首頁</h1>
            <p className="lead">這是我的 React 應用程式首頁</p>
          </header>
          
          <main>
            <section className="card mb-4">
              <div className="card-body">
                <h2 className="card-title">關於我們</h2>
                <Link to="/about" className="btn btn-success">
                  前往關於頁面
                </Link>
                <p className="card-text mt-3">這裡是首頁的主要內容...</p>
              </div>
            </section>
            
            <section className="card">
              <div className="card-body">
                <h2 className="card-title">最新消息</h2>
                <p className="card-text">這裡可以放置最新的資訊...</p>
              </div>
            </section>
          </main>
        </div>
      </div>
    </div>
  );
}

export default Home;