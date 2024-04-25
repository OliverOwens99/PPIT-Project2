const express = require('express');
const bodyParser = require('body-parser');
const fs = require('fs');
const path = './highscores.json';

const cors = require('cors');
//const routes = require('./routes');
//const mongoose = require('mongoose');
require('dotenv').config();
const app = express();

// Middleware
//app.use(bodyParser.json());
app.use(cors());
//app.use(routes);

// use middleware
app.use((req, res, next) => {
    console.log('This is a middleware')
    next()
})

app.use(bodyParser.json());
let highScores;
if (fs.existsSync(path)) {
  highScores = JSON.parse(fs.readFileSync(path, 'utf-8'));
} else {
  highScores = [];
  fs.writeFileSync(path, JSON.stringify(highScores));
}

// Route to handle POST request for high scores
app.post('/highscores', (req, res) => {
  const { username, score } = req.body;

  // Convert score back to a number
  const scoreNumber = Number(score);

  // Store high scores in a JSON file
  const highScores = JSON.parse(fs.readFileSync('highscores.json', 'utf-8'));
  highScores.push({ username, score: scoreNumber });

  fs.writeFileSync('highscores.json', JSON.stringify(highScores));

  console.log('Score added successfully!');

  res.status(200).send('Score added successfully!');
});

app.get('/highscores', (req, res) => {
    const highScores = JSON.parse(fs.readFileSync('highscores.json', 'utf-8'));
    res.status(200).json(highScores);
});

const PORT = process.env.PORT;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to the server' });
});