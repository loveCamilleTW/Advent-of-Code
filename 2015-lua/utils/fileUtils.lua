local FileUtils = {}

function FileUtils.getInput()
    -- Open the file for reading
    local file = io.open('input.txt', 'r')
    if not file then
        error("Failed to open file")
    end

    -- Read the entire content of the file
    local content = file:read('*a')

    -- Close the file
    file:close()
    
    return content
end

return FileUtils