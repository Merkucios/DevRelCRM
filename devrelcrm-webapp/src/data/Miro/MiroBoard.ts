interface MiroBoard {
    id: string;
    type: string;
    name: string;
    description: string;
    picture: {
      imageURL: string;
    };
    viewLink: string;            
  }
  
  export default MiroBoard;