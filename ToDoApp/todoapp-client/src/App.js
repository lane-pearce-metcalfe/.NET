import { useState } from 'react'
import axios from 'axios'

function App() {
  const [title, setTitle] = useState('')

  const addToDo = async () => {
    try {
      const res = await axios.post('https://localhost:5001/api/todo', { title })
      console.log('Added todo:', res.data)
    } catch (err) {
      console.error(err)
    }
  }

  return (
    <div>
      <h1>Add ToDo</h1>
      <input
        type="text"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Todo title"
      />
      <button onClick={addToDo}>Add</button>
    </div>
  )
}

export default App
