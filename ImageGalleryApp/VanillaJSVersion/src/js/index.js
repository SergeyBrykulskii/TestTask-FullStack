const dataSource = "http://188.166.203.164";

async function fetchData() {
  const response = await fetch(`${dataSource}/static/test.json`);
  const data = await response.json();
  return data;
}

async function acceptTermsOfUse(termsOfUse) {
  return new Promise((resolve) => {
    const termsContent = document.getElementById("terms-content");

    termsOfUse.forEach((paragraph) => {
      let paragraphDiv = getParagraphElement(paragraph);
      termsContent.appendChild(paragraphDiv);
    });

    const acceptButton = document.getElementById("accept-button");
    acceptButton.addEventListener("click", () => {
      document.getElementById("terms-of-use").style.display = "none";
      resolve();
    });
  });
}

function getParagraphElement(paragraph) {
  let paragraphDiv = document.createElement("div");
  paragraphDiv.className = "paragraph";

  let subtitle = document.createElement("span");
  subtitle.className = "subtitle";
  subtitle.textContent = paragraph.title;
  paragraphDiv.appendChild(subtitle);

  let content = document.createElement("p");
  content.textContent = paragraph.hasOwnProperty("content")
    ? paragraph.content
    : paragraph.text;

  content.className = "paragraph-text";
  paragraphDiv.appendChild(content);

  return paragraphDiv;
}

async function renderImageToCanvas(imageUrl) {
  const response = await fetch(imageUrl);
  const blob = await response.blob();
  const url = URL.createObjectURL(blob);
  const img = new Image();
  img.src = url;
  return new Promise((resolve) => {
    img.onload = () => {
      const canvas = document.createElement("canvas");
      canvas.width = img.width;
      canvas.height = img.height;
      const ctx = canvas.getContext("2d");
      ctx.drawImage(img, 0, 0);
      const a = document.createElement("a");
      a.href = url;
      a.download = "image.jpg";
      a.textContent = "Save Image";
      a.className = "save-button";
      const div = document.createElement("div");
      div.appendChild(canvas);
      div.appendChild(a);
      resolve(div);
    };
  });
}

function renderImages(images) {
  const gallery = document.getElementById("gallery");

  images.forEach(async (image) => {
    const div = await renderImageToCanvas(
      `${dataSource}${image.image_url}`
    );
    gallery.appendChild(div);
  });
}

async function main() {
  const data = await fetchData();
  await acceptTermsOfUse(data.terms_of_use.paragraphs);

  renderImages(data.images);
}

main();
