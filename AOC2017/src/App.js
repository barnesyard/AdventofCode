import React, { Component } from 'react';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <SpiralGrid/>
      </div>
    );
  }
}

export default App;

class SpiralGrid extends Component {
  createCoordArray () {
    let coords = [];
    let curX = 0;
    let curY = 0;
    let curDir = 0;
    let numMoves = 0;
    let goalMoves = 1;
    let onLegOne = true;
    let moves = [{x: 1, y: 0},{x: 0, y: 1},{x: -1, y: 0},{x: 0, y: -1} ];
    let i = 0;
    do {
      //console.log(" curX: " + curX, " curY: " + curY)
      coords.push({x: curX, y: curY});
     //console.log("Loop: " + i + " %i: " + i%4)
     //console.log(" moveX: " + moves[curDir].x, " moveY: " + moves[curDir].y)
     curX += moves[curDir].x;
     curY += moves[curDir].y;
     numMoves++;
     if(numMoves === goalMoves) {
      curDir = (curDir + 1) % 4;
      numMoves = 0;
      if(!onLegOne) {
        goalMoves++;
        onLegOne = true;
      } else {
        onLegOne = false;
      }
     }
     i++;
    } while (i<289326);
    console.log(coords[289325]);
    return coords;
    }

  render() {
    let myText = "Hello works Line 2";
    this.createCoordArray();
    return (
      <div className="SpiralGrid">
      <Square spiralIndex="289326"/>
      <Square spiralIndex="1"/>
      </div>
    )
  }
}

class Square extends Component {
  render() {
    return (
      <div className = "Square">{this.props.spiralIndex}</div>
    )
  }  
}