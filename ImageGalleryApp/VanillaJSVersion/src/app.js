import express from "express";
import path from "path";
import cors from "cors";

const app = express();
const STATIC_DIR = 'src';
const INDEX_HTML_PATH = path.resolve('./src/templates/index.html');
const port = 3000;

app.use(cors());
app.use(express.static(STATIC_DIR));

app.get('/', (_, res) => {
  res.sendFile(INDEX_HTML_PATH);
});

app.listen(port, () => {
  console.log(`Server running on port http://localhost:${port}`);
});
