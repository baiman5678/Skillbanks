import React from 'react';
import { Link  } from 'react-router-dom';
const About =() =>{
    return (
        <div>
            <h1>關於我們</h1>
            <p>這是關於頁面</p>
            <Link to="/">回到首頁</Link>
        </div>
    );
};

export default About;