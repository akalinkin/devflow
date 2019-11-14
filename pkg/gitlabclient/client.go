package gitlabclient

import (
	"encoding/json"
	"net/http"
	"net/url"
)

// https://medium.com/@marcus.olsson/writing-a-go-client-for-your-restful-api-c193a2f4998c
type Client struct {
	BaseURL   *url.URL
	UserAgent string

	httpClient *http.Client
}

type Board struct {
	Name string
}

func (c *Client) ListBoards() ([]Board, error) {
	rel := &url.URL{Path: "/projects/jkjk/boards"}
	u := c.BaseURL.ResolveReference(rel)
	req, err := http.NewRequest("GET", u.String(), nil)
	if err != nil {
		return nil, err
	}
	req.Header.Set("Accept", "application/json")
	req.Header.Set("User-Agent", c.UserAgent)

	resp, err := c.httpClient.Do(req)
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()
	var boards []Board
	err = json.NewDecoder(resp.Body).Decode(&boards)
	return boards, err
}
