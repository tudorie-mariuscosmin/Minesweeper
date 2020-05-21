import React from 'react';

import Board from './Components/Board';
import './App.css';

//Game component: contains height, width and no of mines
export default class Game extends React.Component {
  state = { //initialize state
    height: 8,
    width: 8,
    mines: 12
  };

  render() {
    //const { height, width, mines } = this.state;
    return ( //pass them to the board component
      <div className="game">
        <Board height={this.state.height} width={this.state.width} mines={this.state.mines} />
      </div>
    );
  }
}
