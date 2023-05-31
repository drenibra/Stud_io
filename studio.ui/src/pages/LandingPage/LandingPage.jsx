import React from 'react';
import './styles.css'
import { Link } from 'react-router-dom';
import Lista from './list.png';
import ListaPritjes from './listing.png';
import Konkursi from './application.png';
import Ankesa from './complaint.png';

export default function LandingPage()
{
  return (

    <div className='base-container'>

      <div className='main-div-landing-page'>
        <div className='ballina-title'>MIRE SE VINI NE STUD.IO</div>
      </div>

      <div className='njoftimet'>
        <p className='njoftimet-e-reja-title'>Njoftimet e reja</p>

        <div className='njoftimet-div'>
          <Link to='#'>
            <img src={Ankesa} />
          </Link>
          <Link to="#">
            <img src={ListaPritjes} />
          </Link>
          <Link to='#'>
            <img src={Lista} />
          </Link>
          <Link to='./Apply'>
            <img src={Konkursi} />
          </Link>
        </div>
        <div className='njoftimet-p'>
          <p>Hapet konkursi per ankese</p>
          <p>Lista e pritjes 22/23</p>
          <p>Lista e rezultateve 22/23</p>
          <p>Hapet konkursi per aplikim <br /> per vitin 2022/23</p>
        </div>

      </div>

    </div>
  )
}