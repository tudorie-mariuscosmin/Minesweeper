import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Board from './Components/Board';
import './App.scss';

//Game component: contains height, width and no of mines
export default class Game extends React.Component {
  state= { //initialize state
    height: 10,
    width: 10,
    mines: 12
  };

  render() {
    const { height, width, mines } = this.state;
    return ( //pass them to the board component
      <div className="game"> 
        <Board height={height} width={width} mines={mines} />
      </div>
    );
  }
}
