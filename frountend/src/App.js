
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import Home from './pages/Home';  // 引入你的 Home 組件
import About  from './pages/about';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          {/* 設置首頁路由 - 當訪問 "/" 時顯示 Home 組件 */}
          <Route path="/" element={<Home />} />
          
          {/* 你可以添加更多路由 */}
          {/* <Route path="/about" element={<About />} /> */}
          <Route path = "/about" element = {<About/>}></Route>
          {/* <Route path="/contact" element={<Contact />} /> */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;