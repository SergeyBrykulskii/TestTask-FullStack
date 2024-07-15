import React, { useState, useEffect } from "react";
import axios from "axios";
import TermsOfUse from "../TermsOfUse/TermsOfUse";
import CanvasImage from "../CanvasImage/CanvasImage";

const dataSource = "http://188.166.203.164";

const ImageGallery = () => {
  const [data, setData] = useState(null);
  const [isTermsAccepted, setIsTermsAccepted] = useState(false);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    const response = await axios.get(`${dataSource}/static/test.json`);
    setData(response.data);
  };

  const handleAcceptTerms = () => {
    setIsTermsAccepted(true);
  };

  if (!data) {
    return <div>Loading...</div>;
  }

  if (!isTermsAccepted) {
    return (
      <TermsOfUse termsOfUse={data.terms_of_use} onAccept={handleAcceptTerms} />
    );
  }

  return (
    <div className="gallery">
      {data.images.map((image) => (
        <div key={image.image_url} className="image-container">
          <CanvasImage imageUrl={`${dataSource}${image.image_url}`} />
          <a href={`${dataSource}${image.image_url}`} download>
            Save Image
          </a>
        </div>
      ))}
    </div>
  );
};

export default ImageGallery;
